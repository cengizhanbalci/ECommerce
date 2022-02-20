using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Services.Abstract
{
    public interface IBasketService
    {
        Task<CustomerBasket> GetBasketAsync(int customerId);

        Task<CustomerBasket> CreateBasket(CustomerBasket basket);

        Task<BasketItem> CreateBasketItem(BasketItem basketItem);

        Task<CustomerBasket> UpdateBasket(CustomerBasket basket);

        Task DeleteBasket(int customerId);

        Task DeleteBasketItem(int customerId, int itemId);
    }
}
