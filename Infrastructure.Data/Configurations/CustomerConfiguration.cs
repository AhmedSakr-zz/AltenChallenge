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
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var customers=new List<Customer>
            {
                new Customer{Id = 1, FullName = "Kalles Grustransporter AB", Address = "Cementvägen 8, 111 11 Södertälje", CreatedById = -1,CreatedDate = DateTime.Now},
                new Customer{Id = 2, FullName = "Johans Bulk AB", Address = "Balkvägen 12, 222 22 Stockholm", CreatedById = -1,CreatedDate = DateTime.Now},
                new Customer{Id = 3, FullName = "Haralds Värdetransporter AB", Address = "Budgetvägen 1, 333 33 Uppsala", CreatedById = -1,CreatedDate = DateTime.Now},
            };

            builder.HasData(customers);
        }
    }
}
