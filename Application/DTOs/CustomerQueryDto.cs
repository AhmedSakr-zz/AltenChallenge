using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.DTOs
{
    public class CustomerQueryDto : IRequest<List<CustomerForReturnDto>>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
