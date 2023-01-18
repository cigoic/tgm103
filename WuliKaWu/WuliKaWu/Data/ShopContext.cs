using Microsoft.EntityFrameworkCore;

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    //public class ShopContext :: IdentityDbContext<Member, IdentityRole<int>, int>     // 改用 Identity
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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Member> Members { get; set; }      // 若改用 Identity, 此行要移除

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Price = 100,
                ProductName = "大衣",
                Color = Color.Black,
                Size = Size.S,
                Category = Category.Dress,
                StarRate = StarRate.NoStar,
                SellingPrice = 100,
                ProductId = 1,
                Picture = "pic1"
            });
        }
    }
}