using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Microservice.Middleware
{
    public class UserKeyValidatorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public UserKeyValidatorsMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Path.StartsWithSegments(new PathString("/api")))
            {
                //Let's check if this is an API Call
                if (context.Request.Headers.Keys.Contains("ApiKey", StringComparer.InvariantCultureIgnoreCase))
                {
                    // validate the supplied API key
                    var headerKey = context.Request.Headers["ApiKey"].FirstOrDefault();
                    if (headerKey == _configuration["ApiKey"])
                    {
                        await _next.Invoke(context);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await context.Response.WriteAsync("Invalid API Key");
                    }
                }
                else
                {
                    context.Response.StatusCode = 400; //Bad Request                
                    await context.Response.WriteAsync("User Key is missing");
                    return;
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }

    #region ExtensionMethod
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder ApplyUserKeyValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidatorsMiddleware>();
            return app;
        }
    }
    #endregion
}
