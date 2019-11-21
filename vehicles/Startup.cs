using System;
using System.Linq;
using System.Text;
using Application.Behaviors;
using AutoMapper;
using Hangfire;
using Infrastructure.Data.Services;
using Infrastructure.IoC;
using MediatR;
using Microservice.Extensions;
using Microservice.Logging;
using Microservice.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Microservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // configure swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "vehicle Microservice", Version = "V1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            // configure HangFire (for schedule task)
            services.AddHangfire(configuration =>
                configuration.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));

            // configure DbContext
            services.AddDbContext<AppDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("vehicles")));
            services.AddScoped<DbContext, AppDbContext>();

            // configure AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configure MediatR
            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>));


            //configure logging
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<ApplicationLog>>();
            services.AddSingleton(typeof(ILogger), logger);

            //jwt 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["ValidIssuer"],
                        ValidAudience = Configuration["ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWtKey"]))
                    };
                });

            // configure data services and application service
            DependencyContainer.RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHangfireServer();

            app.UseHangfireDashboard();

            app.UseDeveloperExceptionPage();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle Microservice API V1");
            });

            app.UseCors("CorsPolicy");

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            //app.ApplyUserKeyValidation();

            app.UseAuthentication();

            app.UseMvc();

        }
    }
}
