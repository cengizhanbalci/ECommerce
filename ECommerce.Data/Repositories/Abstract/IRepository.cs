using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
