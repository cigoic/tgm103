using Microsoft.EntityFrameworkCore;
using static WuliKaWu.Data.Enums.Common;
using WuliKaWu.Data;

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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<WuliKaWu.Data.WishList> WishList { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Member> Members { get; set; }      // 若改用 Identity, 此行要移除
        public DbSet<MemberRole> MemberRoles { get; set; }      // 若改用 Identity, 此行要移除

        public DbSet<TableOfGetPayType> TbGetPayTypes { get; set; }

        public DbSet<TableOfSize> TbSizes { get; set; }

        public DbSet<TableOfColor> TbColors { get; set; }

        public DbSet<TableOfStarRate> TbStars { get; set; }

        public DbSet<TableOfCategory> TbCategories { get; set; }

        public DbSet<TableOfTag> TbTags { get; set; }

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
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                CartId = 1,
                ProductName = "裙子",
                Picture = "pic1",
                Color = Color.Red,
                Size = Size.M,
                Price = 1000,
                SellingPrice = 800,
                Coupon = -100
            });
            modelBuilder.Entity<WishList>().HasData(new WishList
            {
                WishListId = 1,
                ProductName = "牛仔外套",
                Price = 3000,
                SellingPrice = 2700,
                Discount = -1000,
                Picture = "pic2"
            });
        }
    }
}