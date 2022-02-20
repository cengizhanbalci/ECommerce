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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return _unitOfWork.Categories.GetAll().ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Categories.GetById(id);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _unitOfWork.Categories.Create(category);

            return category;
        }

        public async Task UpdateCategory(Category category)
        {
            await _unitOfWork.Categories.Update(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategory(int id)
        {
            await _unitOfWork.Categories.Delete(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
