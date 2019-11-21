using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public  DbSet<Customer> Customers { get; set; }
        public  DbSet<Car> Cars { get; set; }
        public DbSet<CarStatus> CarStatuses { get; set; }
        public DbSet<CarStatusTransaction> CarStatusTransactions { get; set; }
        public DbSet<LogData> LogDatas { get; set; }

        //Seeding initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CarsConfiguration());
            modelBuilder.ApplyConfiguration(new CarStatusConfiguration());
        }
    }
}
