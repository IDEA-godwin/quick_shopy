

using QuickShoppy.Models;
using QuickShoppy.Dto;

namespace QuickShoppy.Services {

    public interface ICartService
    {
        public Task<Cart> AddItemToCart (AddToCartDto addToCartDto);

        public CartProductsDto GetCartItems(int cartId);

        public Cart GetCart(int cartId);

        public Task<Cart> CreateCart();

    }
}