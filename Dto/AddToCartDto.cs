
namespace QuickShoppy.Dto {
    public class AddToCartDto
    {
        public string ItemCode { get; set; } = "";
        public int ItemQuantity { get; set; }
        public bool HasCart { get; set; }
        public int CartId { get; set; }

    }
}


