using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.DTOs
{
    public class CarStatusTransactionForReturnDto : INotification
    {
        public int CarId { get; set; }
        public int StatusId { get; set; }
    }
}
