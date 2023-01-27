﻿using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// 商品圖片資料表
        /// </summary>
        public DbSet<Picture> Pictures { get; set; }

        /// <summary>
        /// 訂單明細表
        /// </summary>
        public DbSet<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// 部落格文章表
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// 部落格文章 - 分類關聯表
        /// </summary>
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        /// <summary>
        /// 部落格文章 - 標題影像關聯表
        /// </summary>
        public DbSet<ArticleTitleImage> ArticleTitleImages { get; set; }

        /// <summary>
        /// 部落格文章 - 內容影像關聯表
        /// </summary>
        public DbSet<ArticleContentImage> ArticleContentImages { get; set; }

        /// <summary>
        /// 部落格文章 - 作者大頭圖像關聯表
        /// </summary>
        public DbSet<AuthorImage> AuthorImages { get; set; }

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
            modelBuilder.Entity<OrderDetails>().HasData(new OrderDetails
            {
                OrderDetailsId = 1,
                ShippingAddress = "台北市中山區南京西路1號",
                Recipient = "王大明",
                ContactPhone = "0900123456",
                PicturePath = "pic1",
                ProductName = "外套",
                Color = Color.Brown,
                Quantity = 2,
                Size = Size.XL,
                Price = 3600,
                SellingPrice = 2000,
                Type = GetPayType.CreditCard,
                Coupon = -100,
            });

            modelBuilder.Entity<Member>().HasData(new Member
            {
                MemberId = 1,
                Account = "userOne",
                Password = "1314520",
                Name = "NameOfUserOne",
                Gender = false,
                Birthday = DateTime.Now,
                Email = "123@123.com",
                EmailComfirmed = true,
                Address = "台北市中山區",
                PhoneNumber = "1234567890",
                MobilePhone = "0987654321",
                MemberShip = MemberShipType.NormalUser,
                LockOutEnabled = false,
                AccessFailedCount = 0,
            });
            modelBuilder.Entity<Article>().HasData(new Article
            {
                ArticleId = 1,
                MemberId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Title = "Lorem ipsum dolor consectet.",
                Content = "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.",
            });
            modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
            {
                Id = 1,
                ArticleId = 1,
                Type = ArticleType.LatestBlog,
            });
            modelBuilder.Entity<ArticleTitleImage>().HasData(new ArticleTitleImage
            {
                Id = 1,
                ArticleId = 1,
                FileName = "~/assets/images/blog/blog-details.png",
            });
            modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
            {
                Id = 1,
                ArticleId = 1,
                FileName = "~/assets/images/blog/blog-details-2.png"
            });
            modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
            {
                Id = 2,
                ArticleId = 1,
                FileName = "~/assets/images/blog/blog-details-3.png"
            });
            modelBuilder.Entity<AuthorImage>().HasData(new AuthorImage
            {
                Id = 1,
                MemberId = 1,
                FirstImageFileName = "~/assets/images/blog/blog-author.png",
                SecondImageFileName = "~/assets/images/blog/blog-author-2.png",
            });
        }
    }
}