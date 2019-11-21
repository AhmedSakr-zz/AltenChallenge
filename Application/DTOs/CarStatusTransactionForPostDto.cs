using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.DTOs
{
    public class CarStatusTransactionForPostDto : IRequest<bool>
    {
        //[Required] //No need for validation attribute as int type is not null by default
        public int CarId { get; set; }
        public int StatusId { get; set; }
    }
}
