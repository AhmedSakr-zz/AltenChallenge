using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarStatusTransaction : AuditEntityBase
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public CarStatus CarStatus { get; set; }

    }
}
