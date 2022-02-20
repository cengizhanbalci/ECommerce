using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories.Abstract
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(int customerId);

        Task<CustomerBasket> CreateBasketAsync(CustomerBasket basket);

        Task<IEnumerable<BasketItem>> CreateBasketItemAsync(BasketItem basket);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(int customerId);

        Task<IEnumerable<BasketItem>> GetBasketItemsAsync(int customerId);

        Task<bool> DeleteBasketItemAsync(int customerId, int itemId);
    }
}
