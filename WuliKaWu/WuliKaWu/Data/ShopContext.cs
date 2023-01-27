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

        /// <summary>
        /// 商品資料表
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 訂單資料表
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 購物車資料表
        /// </summary>
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// 願望清單資料表
        /// </summary>
        public DbSet<WuliKaWu.Data.WishList> WishList { get; set; }

        /// <summary>
        /// 聯絡資訊資料表
        /// </summary>
        public DbSet<ContactMessage> ContactMessages { get; set; }

        /// <summary>
        /// 使用者資料表
        /// </summary>
        public DbSet<Member> Members { get; set; }      // 若改用 Identity, 此行要移除

        /// <summary>
        /// 使用者角色資料表
        /// </summary>
        public DbSet<MemberRole> MemberRoles { get; set; }      // 若改用 Identity, 此行要移除

        /// <summary>
        /// 支付方式資料表
        /// </summary>
        public DbSet<TableOfGetPayType> TbGetPayTypes { get; set; }

        /// <summary>
        /// 商品尺寸資料表
        /// </summary>
        public DbSet<TableOfSize> TbSizes { get; set; }

        /// <summary>
        /// 商品顏色資料表
        /// </summary>
        public DbSet<TableOfColor> TbColors { get; set; }

        /// <summary>
        /// 商品星等資料表
        /// </summary>
        public DbSet<TableOfStarRate> TbStars { get; set; }

        /// <summary>
        /// 商品分類資料表
        /// </summary>
        public DbSet<TableOfCategory> TbCategories { get; set; }

        /// <summary>
        /// 商品標籤資料表
        /// </summary>
        public DbSet<TableOfTag> TbTags { get; set; }

        //TODO
        /// <summary>
        /// Seed
        /// </summary>
        /// <param name="modelBuilder"></param>
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
                PicturePath = "pic1"
            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                CartId = 1,
                ProductName = "裙子",
                PicturePath = "pic1",
                Color = Color.Red,
                Size = Size.M,
                Price = 1000,
                SellingPrice = 800,
                Coupon = -100,
                Quantity = 2,
            });
            modelBuilder.Entity<WishList>().HasData(new WishList
            {
                WishListId = 1,
                ProductName = "牛仔外套",
                Price = 3000,
                SellingPrice = 2700,
                Discount = -1000,
                PicturePath = "pic2"
            });
        }
    }
}