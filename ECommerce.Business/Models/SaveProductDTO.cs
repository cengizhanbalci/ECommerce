using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Models
{
    public class SaveProductDTO
    {
        public string Name { get; set; }
        public int QuantityAvailable { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
