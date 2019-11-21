using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Services;
using Infrastructure.Data.Contracts;
using Infrastructure.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Data Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarStatusRepository, CarStatusRepository>();
            services.AddScoped<ICarStatusTransactionRepository, CarStatusTransactionRepository>();
            services.AddScoped<ILogDataRepository, LogDataRepository>();

            //Application Services
            services.AddScoped<ICarServices, CarServices>();
            services.AddScoped<IDBLogService, DbLogDataService>();
            services.AddScoped<IFakeSendCarStatusServices, FakeSendCarStatusServices>();
        }
    }
}
