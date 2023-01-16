using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace WuliKaWu.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<CartViewModel> Carts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product {
                Price = 100,
                ProductName = "大衣",
                Color = Color.Black,
                Size = Size.S,
                Category = Category.Dress,
                StarRate = StarRate.NoStar,
                SellingPrice = 100,
                ProductId = 1,
                Picture = new byte[10]                
                
                

            });

        }
    }
}