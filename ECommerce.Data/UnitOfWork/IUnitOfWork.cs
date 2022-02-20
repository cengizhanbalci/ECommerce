using ECommerce.Core.Repositories;
using ECommerce.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IBasketRepository Baskets { get; }
        Task<int> CommitAsync();
    }
}
