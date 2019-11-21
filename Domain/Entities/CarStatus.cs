using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //lockups table
    //No need for audit fields  (: AuditEntityBase)
    public class CarStatus
    {
        public CarStatus()
        {
            StatusTransactions = new List<CarStatusTransaction>();
            Cars = new List<Car>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public List<CarStatusTransaction> StatusTransactions { get; set; }
        public List<Car> Cars { get; set; }

    }
}
