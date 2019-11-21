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
    public class CarStatusTransactionConfiguration : IEntityTypeConfiguration<CarStatusTransaction>
    {
        public void Configure(EntityTypeBuilder<CarStatusTransaction> builder)
        {
            var transactions=new List<CarStatusTransaction>
            {
                new CarStatusTransaction{Id = 1, CarId = 1, StatusId = 1,CreatedById = -1,CreatedDate = DateTime.Now},
                new CarStatusTransaction{Id = 2, CarId = 2, StatusId = 1,CreatedById = -1,CreatedDate = DateTime.Now},
                new CarStatusTransaction{Id = 3, CarId = 3, StatusId = 2,CreatedById = -1,CreatedDate = DateTime.Now},
                new CarStatusTransaction{Id = 4, CarId = 4, StatusId = 1,CreatedById = -1,CreatedDate = DateTime.Now},
                new CarStatusTransaction{Id = 5, CarId = 5, StatusId = 1,CreatedById = -1,CreatedDate = DateTime.Now},
                new CarStatusTransaction{Id = 6, CarId = 6, StatusId = 1,CreatedById = -1,CreatedDate = DateTime.Now},
                new CarStatusTransaction{Id = 7, CarId = 7, StatusId = 2,CreatedById = -1,CreatedDate = DateTime.Now},
            };
        }
    }
}
