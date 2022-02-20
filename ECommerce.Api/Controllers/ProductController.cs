using AutoMapper;
using ECommerce.Business.Models;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productService.GetAllProducts();

            if (products.Count() == 0)
                return NotFound("Product not found.");

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(int id)
        {
            var product = await _productService.GetProductById(id);

            return product;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] SaveProductDTO saveProduct)
        {
            var product = _mapper.Map<Product>(saveProduct);

            await _productService.CreateProduct(product);

            return Ok();
        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] SaveProductDTO saveProduct, int id)
        {
            var product = _mapper.Map(saveProduct, await GetById(id));

            await _productService.UpdateProduct(product);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _productService.DeleteProduct(id);

            return Ok();
        }
    }
}