using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CarsConfiguration:IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            var cars = new List<Car>
            {
                new Car{Id = 1, CustomerId = 1, CurrentStatusId = 1, RegNo = "ABC123", VehicleId = "YS2R4X20005399401", CreatedById = -1, CreatedDate = DateTime.Now},
                new Car{Id = 2, CustomerId = 1, CurrentStatusId = 1, RegNo = "DEF456", VehicleId = "VLUR4X20009093588", CreatedById = -1, CreatedDate = DateTime.Now},
                new Car{Id = 3, CustomerId = 1, CurrentStatusId = 2, RegNo = "GHI789", VehicleId = "VLUR4X20009048066", CreatedById = -1, CreatedDate = DateTime.Now},
                new Car{Id = 4, CustomerId = 2, CurrentStatusId = 1, RegNo = "JKL012", VehicleId = "YS2R4X20005388011", CreatedById = -1, CreatedDate = DateTime.Now},
                new Car{Id = 5, CustomerId = 2, CurrentStatusId = 1, RegNo = "MNO345", VehicleId = "YS2R4X20005387949", CreatedById = -1, CreatedDate = DateTime.Now},
                new Car{Id = 6, CustomerId = 3, CurrentStatusId = 1, RegNo = "PQR678", VehicleId = "VLUR4X20009048066", CreatedById = -1, CreatedDate = DateTime.Now},
                new Car{Id = 7, CustomerId = 3, CurrentStatusId = 2, RegNo = "STU901", VehicleId = "YS2R4X20005387055", CreatedById = -1, CreatedDate = DateTime.Now},
            };

            builder.HasData(cars);
        }
    }
}
