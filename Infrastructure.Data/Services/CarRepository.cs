using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Services
{
    public class CarRepository:Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext context) : base(context)
        {
        }
    }
}
