
namespace QuickShoppy.Dto {
    public class CartProductsDto
    {

        public CartProductsDto(int cartId) {
            CartId = cartId;
        }
        
        public int CartId { get; set; }

        public IEnumerable<ProductDto> Products { get; set; } = Enumerable.Empty<ProductDto>();
    }
}

