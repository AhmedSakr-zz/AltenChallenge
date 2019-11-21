using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : AuditEntityBase
    {
        public Customer()
        {
            Cars = new List<Car>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string FullName { get; set; }
        [MaxLength(400)]
        public string Address { get; set; }
        public List<Car> Cars { get; set; }
    }
}
