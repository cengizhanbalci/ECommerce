using ECommerce.Core;
using ECommerce.Core.Repositories;
using ECommerce.Data.Repositories;
using ECommerce.Data.Repositories.Abstract;
using ECommerce.Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _dbContext;

        private ProductRepository _productRepository;

        private CategoryRepository _categoryRepository;

        private BasketRepository _basketRepository;

        public UnitOfWork(ECommerceDbContext dbContext) => _dbContext = dbContext;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_dbContext);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_dbContext);

        public IBasketRepository Baskets => _basketRepository = _basketRepository ?? new BasketRepository(_dbContext);

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
