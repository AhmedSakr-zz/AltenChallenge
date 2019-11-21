using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ui.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Customers = new List<CustomerForReturnDto>();
            Cars = new List<CarForReturnDto>();
        }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public string CustomerName { get; set; }
        public string StatusName { get; set; }
        public List<CustomerForReturnDto> Customers { get; set; }
        public List<CarForReturnDto> Cars { get; set; }

    }
}
