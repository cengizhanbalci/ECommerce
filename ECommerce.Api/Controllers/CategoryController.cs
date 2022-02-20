using AutoMapper;
using ECommerce.Business.Models;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _categoryService.GetAllCategories();

            if (categories.Count() == 0)
                return NotFound("Category not found.");

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<Category> GetById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            return category;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] SaveCategoryDTO saveCategory)
        {
            var category = _mapper.Map<Category>(saveCategory);

            await _categoryService.CreateCategory(category);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] SaveCategoryDTO saveCategory, int id)
        {
            var category = _mapper.Map(saveCategory, await GetById(id));

            await _categoryService.UpdateCategory(category);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);

            return Ok();
        }
    }
}
