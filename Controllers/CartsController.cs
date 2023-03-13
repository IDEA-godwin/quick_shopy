

using Microsoft.AspNetCore.Mvc;

using QuickShoppy.Models;
using QuickShoppy.Services;
using QuickShoppy.Dto;

namespace QuickShopy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartHelper) {
            cartService = cartHelper;
        }

        [HttpPut("add")]
        public async Task<ActionResult<Cart>> AddItemToCart(AddToCartDto addToCartDto) {
            return await cartService.AddItemToCart(addToCartDto);
        }

        [HttpGet("{id}")]
        public ActionResult<CartProductsDto> GetCart(int id) {
            return Ok(cartService.GetCart(id));
        } 

        [HttpGet("{id}/products")]
        public ActionResult<CartProductsDto> GetCartProducts(int id) {
            return cartService.GetCartItems(id);
        }
    }
}