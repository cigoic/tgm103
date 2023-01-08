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
<<<<<<< HEAD
        public DbSet<CartViewModel> Carts { get; set; }
=======
        public DbSet<ContactMessage> ContactMessages { get; set; }
>>>>>>> c6fc7ab427c365ddafb40d8aa1ce9819c186af5f
    }
}