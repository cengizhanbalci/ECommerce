using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }
        public int QuantityAvailable { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
