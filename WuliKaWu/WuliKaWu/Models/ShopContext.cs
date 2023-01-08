using Microsoft.EntityFrameworkCore;

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
    }
}