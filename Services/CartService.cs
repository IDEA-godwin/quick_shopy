


using System.Net;
using Microsoft.EntityFrameworkCore;

using QuickShoppy.Data;
using QuickShoppy.Models;
using QuickShoppy.Dto;

namespace QuickShoppy.Services {

    
    public class CartService : ICartService
    {
        private readonly AppDbContext _dbContext;

        public CartService(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Cart> AddItemToCart (AddToCartDto addToCartDto) {
            Cart cart; 
            if (addToCartDto.HasCart) cart = GetCart(addToCartDto.CartId);
            else cart = await CreateCart();

            Product product = getProduct(addToCartDto.ItemCode);

            if (product.QuantityInStock < addToCartDto.ItemQuantity)
                throw new HttpRequestException("We can not currently meet the quantity of purchase", new Exception(), HttpStatusCode.UnprocessableEntity);

            product.QuantityInStock -= addToCartDto.ItemQuantity;

            cart!.NumberOfItems = addToCartDto.ItemQuantity;
            cart!.TotalAmountOfItems = calculateCartTotal(product.Price, addToCartDto.ItemQuantity, cart.TotalAmountOfItems);

            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.Entry(cart).State = EntityState.Modified;

            CartProduct cartProduct = new CartProduct();
            cartProduct.ProductQuantity = addToCartDto.ItemQuantity;
            cartProduct.Cart = cart;
            cartProduct.CartId = cart.Id;
            cartProduct.Product = product;
            cartProduct.ProductId = product.Id;

            _dbContext.CartProducts.Add(cartProduct);

            await _dbContext.SaveChangesAsync();

            return cart;
        }

        public CartProductsDto GetCartItems(int cartId) {
            CartProductsDto cartProductsDto = new CartProductsDto(cartId);
            cartProductsDto.Products = getProducts(cartId);
            return cartProductsDto;
        }

        IEnumerable<ProductDto> getProducts(int cartId) {
            var result =  _dbContext.CartProducts
                .Join(_dbContext.Products, cp => cp.ProductId, p => p.Id, (cp, p) => new { cp, p})
                .Where(query => query.cp.CartId.Equals(cartId));
            foreach (var item in result)
            {
                yield return new ProductDto(item.p);
            }
        }

        public Cart GetCart(int cartId) {
            Cart? cart = _dbContext.Carts
                    .Where(c => c.Id.Equals(cartId))
                    .FirstOrDefault();

            if (cart is not null) return cart;
            
            throw new HttpRequestException("Cart Not Found", new Exception(), HttpStatusCode.NotFound);
        }

        public async Task<Cart> CreateCart() {
            Cart cart = new Cart();
            cart.NumberOfItems = 0;
            cart.TotalAmountOfItems = "0.00";
            _dbContext.Carts.Add(cart);
            await _dbContext.SaveChangesAsync();
            return cart;
        }

        Product getProduct(string itemCode) {
            Product? product = _dbContext.Products
                        .Where(p => p.ItemCode!.Equals(itemCode))
                        .FirstOrDefault();
            
            if (product is not null) return product;

            throw new HttpRequestException("Product Not Found", new Exception(), HttpStatusCode.NotFound);
        }

        

        String calculateCartTotal(String price, int quantity, String currentTotal) {

            double itemPrice = 0.0, cartTotal = 0.0;
            bool priceToDouble = Double.TryParse(price, out itemPrice);
            bool totalToDouble = Double.TryParse(currentTotal, out cartTotal);

            if (!(priceToDouble && totalToDouble))
                throw new Exception();

            double result = cartTotal + (itemPrice * quantity);

            
            return result.ToString("#.##");
        }

        void throwNotFoundException(string message) {
            throw new HttpRequestException("Cart Not Found", new Exception(), HttpStatusCode.NotFound);
        }

        
    }
}