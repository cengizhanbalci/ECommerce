using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
