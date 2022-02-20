using ECommerce.Core.Entities;
using ECommerce.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories.Concrete
{
    public class BasketRepository : Repository<CustomerBasket>, IBasketRepository
    {
        private readonly DbContext _dbContext;

        public BasketRepository(DbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<bool> DeleteBasketAsync(int customerId)
        {
            var basket = await _dbContext.Set<CustomerBasket>().FirstOrDefaultAsync(x => x.BuyerId == customerId);
            _dbContext.Set<CustomerBasket>().Remove(basket);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBasketItemAsync(int customerId, int itemId)
        {
            var basketItem = await _dbContext.Set<BasketItem>().FirstOrDefaultAsync(x => x.Id == customerId && x.ProductId == itemId);
            _dbContext.Set<BasketItem>().Remove(basketItem);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CustomerBasket> GetBasketAsync(int customerId)
        {
            var basket = await _dbContext.Set<CustomerBasket>().AsNoTracking().Include(c => c.Items).FirstOrDefaultAsync(x => x.BuyerId == customerId);

            return basket;
        }

        public async Task<IEnumerable<BasketItem>> GetBasketItemsAsync(int customerId)
        {
            var basketItems = _dbContext.Set<BasketItem>().AsNoTracking().Where(x => x.CustomerId == customerId).ToList();

            return basketItems;
        }

        public async Task<CustomerBasket> CreateBasketAsync(CustomerBasket basket)
        {
            await _dbContext.Set<CustomerBasket>().AddAsync(basket);
            await _dbContext.SaveChangesAsync();

            return await GetBasketAsync(basket.BuyerId);
        }

        public async Task<IEnumerable<BasketItem>> CreateBasketItemAsync(BasketItem basketItem)
        {
            await _dbContext.Set<BasketItem>().AddAsync(basketItem);
            await _dbContext.SaveChangesAsync();

            return await GetBasketItemsAsync(basketItem.CustomerId);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            _dbContext.Set<CustomerBasket>().Update(basket);
            await _dbContext.SaveChangesAsync();

            return await GetBasketAsync(basket.BuyerId);
        }
    } 
}
