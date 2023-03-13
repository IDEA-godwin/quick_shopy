

namespace QuickShoppy.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("products")]
public class Product 
{

    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string Price { get; set; } = "0.00";

    public string? Description { get; set; }

    
    public string? ItemCode { get; set; }

    public int QuantityInStock { get; set; }


}