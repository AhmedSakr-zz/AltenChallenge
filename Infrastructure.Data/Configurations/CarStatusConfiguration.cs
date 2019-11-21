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
    public class CarStatusConfiguration:IEntityTypeConfiguration<CarStatus>
    {
        public void Configure(EntityTypeBuilder<CarStatus> builder)
        {
            var carStatus=new List<CarStatus>
            {
                new CarStatus{Id = 1, Name = "Connected"},
                new CarStatus{Id = 2, Name = "Disconnected"},
            };
            builder.HasData(carStatus);
        }
    }
}
