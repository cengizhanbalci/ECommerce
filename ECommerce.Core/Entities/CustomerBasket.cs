using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public sealed class CustomerBasket : BaseEntity
    {
        public int BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public CustomerBasket()
        {

        }

        public CustomerBasket(int customerId)
        {
            BuyerId = customerId;
        }
    }
}
