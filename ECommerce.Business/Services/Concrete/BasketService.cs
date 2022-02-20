using ECommerce.Business.Services.Abstract;
using ECommerce.Core;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Services.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerBasket> GetBasketAsync(int customerId)
        {
            return await _unitOfWork.Baskets.GetBasketAsync(customerId);
        }

        public async Task<IEnumerable<BasketItem>> GetBasketItemsAsync(int customerId)
        {
            return await _unitOfWork.Baskets.GetBasketItemsAsync(customerId);
        }

        public async Task<CustomerBasket> CreateBasket(CustomerBasket basket)
        {
            await _unitOfWork.Baskets.CreateBasketAsync(basket);

            return basket;
        }

        public async Task<BasketItem> CreateBasketItem(BasketItem basketItem)
        {
            await _unitOfWork.Baskets.CreateBasketItemAsync(basketItem);

            return basketItem;
        }

        public async Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
        {
            await _unitOfWork.Baskets.UpdateBasketAsync(basket);

            return basket;
        }

        public async Task DeleteBasket(int customerId)
        {
            var basketItems = await GetBasketItemsAsync(customerId);

            await _unitOfWork.Baskets.DeleteBasketAsync(customerId);

            foreach (var item in basketItems)
                await _unitOfWork.Baskets.DeleteBasketItemAsync(item.CustomerId, item.ProductId);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteBasketItem(int customerId, int itemId)
        {
            await _unitOfWork.Baskets.DeleteBasketItemAsync(customerId, itemId);
            await _unitOfWork.CommitAsync();
        }
    }
}
