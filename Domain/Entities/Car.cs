using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : AuditEntityBase
    {
        public Car()
        {
            StatusTransactions = new List<CarStatusTransaction>();
        }
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? CurrentStatusId { get; set; }
        [MaxLength(17)]
        public string VehicleId { get; set; }
        [MaxLength(6)]
        public string RegNo { get; set; }
        [ForeignKey("CurrentStatusId")]
        public CarStatus CarStatus { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<CarStatusTransaction> StatusTransactions { get; set; }
    }
}
