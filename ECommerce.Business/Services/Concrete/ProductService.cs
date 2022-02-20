using ECommerce.Core;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return _unitOfWork.Products.GetAll().ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Products.GetById(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _unitOfWork.Products.Create(product);

            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            await _unitOfWork.Products.Update(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteProduct(int id)
        {
            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
