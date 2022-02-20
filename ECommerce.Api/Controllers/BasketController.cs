using ECommerce.Business.Services.Abstract;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketByIdAsync(int customerId)
        {
            var basket = await _basketService.GetBasketAsync(customerId);

            return Ok(basket ?? new CustomerBasket(customerId));
        }

        [HttpPost("AddItemToBasket")]
        public async Task<IActionResult> AddItemToBasket([FromBody] BasketItem basketItem)
        {
            #region stock control
            var productQuantity = await _productService.GetProductById(basketItem.ProductId);

            if (productQuantity != null ? (productQuantity.QuantityAvailable == 0) : true)
                return NotFound("The added product is not available in stock.");
            #endregion

            var basket = await _basketService.GetBasketAsync(basketItem.CustomerId);

            if (basket == null)
            {
                basket = new CustomerBasket(basketItem.CustomerId);
                await _basketService.CreateBasket(basket);
            }

            await _basketService.CreateBasketItem(basketItem);

            basket.Items.Add(basketItem);

            await _basketService.UpdateBasket(basket);

            return Ok();
        }

        [HttpDelete("ClearBasket/{customerId}")]
        public async Task<IActionResult> DeleteBasketByCustomerId(int customerId)
        {
            await _basketService.DeleteBasket(customerId);

            return Ok();
        }

        [HttpDelete("DeleteItemFromBasket/{customerId}/{itemId}")]
        public async Task<IActionResult> DeleteItemFromBasket(int customerId, int itemId)
        {
            await _basketService.DeleteBasketItem(customerId, itemId);

            return Ok();
        }
    }
}
