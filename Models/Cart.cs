
namespace QuickShoppy.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("carts")]
public class Cart 
{

    public int Id { get; set;}

    public int NumberOfItems { get; set; }

    public string TotalAmountOfItems { get; set; } = "0.00";
}