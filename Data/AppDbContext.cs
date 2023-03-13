
namespace QuickShoppy.Data;

using Microsoft.EntityFrameworkCore;
using QuickShoppy.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {  }

    public DbSet<Product> Products { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartProduct> CartProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartProduct>()
            .HasKey(t => new { t.CartId, t.ProductId });

        modelBuilder.Entity<CartProduct>()
            .HasOne(pt => pt.Cart)
            .WithMany()
            .HasForeignKey(pt => pt.CartId);

        modelBuilder.Entity<CartProduct>()
            .HasOne(pt => pt.Product)
            .WithMany()
            .HasForeignKey(pt => pt.ProductId);
    }
}