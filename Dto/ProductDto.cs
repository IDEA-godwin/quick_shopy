

using QuickShoppy.Models;

namespace QuickShoppy.Dto {
    public class ProductDto
    {
        public ProductDto()
        { }

        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
            ItemCode = product.ItemCode;
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public string Price { get; set; } = "0.00";

        public string? Description { get; set; }

        public string? ItemCode { get; set; }
    }
}
