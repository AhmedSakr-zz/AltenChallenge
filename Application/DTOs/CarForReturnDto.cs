using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CarForReturnDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public string VehicleId { get; set; }
        public string RegNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Status { get; set; }
    }
}
