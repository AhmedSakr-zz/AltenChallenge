using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.DTOs
{
    public class CarQueryDto : IRequest<List<Car>>
    {
        public int? CustomerId { get; set; }
        public int? StatusId { get; set; }
    }
}
