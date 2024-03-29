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
        public DbSet<WishList> WishList { get; set; }

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
        /// 產生過的重置密碼 Token
        /// </summary>
        public DbSet<ResetToken> ResetTokens { get; set; }

        

        

        /// <summary>
        /// 商品顏色資料表
        /// </summary>
        public DbSet<Color> Colors { get; set; }

        /// <summary>
        /// 商品星等資料表
        /// </summary>
        public DbSet<StarRate> StarRate { get; set; }

        /// <summary>
        /// 商品分類資料表
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// 商品標籤資料表
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    int countArticle = 0;   // assign to Article Id
        //    int countContentImage = 0;  // assign to ArticleContentImage's Id

        //    modelBuilder.Entity<Product>().HasData(new Product
        //    {
        //        Price = 100,
        //        ProductName = "大衣",
        //        Color = Color.Black,
        //        Size = Size.S,
        //        CategoryId = (int)Category.Dress,
        //        StarRate = StarRate.NoStar,
        //        SellingPrice = 100,
        //        ProductId = 1,
        //        PicturePath = "pic1"
        //    });

        //    // 會員
        //    modelBuilder.Entity<Member>().HasData(new Member
        //    {
        //        MemberId = 1,
        //        Account = "userOne",
        //        Password = "1314520",
        //        Name = "NameOfUserOne",
        //        Gender = false,
        //        Birthday = DateTime.Now,
        //        Email = "123@123.com",
        //        EmailComfirmed = true,
        //        Address = "台北市中山區",
        //        PhoneNumber = "1234567890",
        //        MobilePhone = "0987654321",
        //        MemberShip = MemberShipType.NormalUser,
        //        LockOutEnabled = false,
        //        AccessFailedCount = 0,
        //    });

        //    // VIP
        //    modelBuilder.Entity<Member>().HasData(new Member
        //    {
        //        MemberId = 2,
        //        Account = "userTwo",
        //        Password = "tgm10322",
        //        Name = "NameOfVIP",
        //        Gender = false,
        //        Birthday = DateTime.Now,
        //        Email = "456@456.com",
        //        EmailComfirmed = true,
        //        Address = "台中市中正區",
        //        PhoneNumber = "0448938627",
        //        MobilePhone = "0912345678",
        //        MemberShip = MemberShipType.VIP,
        //        LockOutEnabled = false,
        //        AccessFailedCount = 0,
        //    });

        //    // 管理員
        //    modelBuilder.Entity<Member>().HasData(new Member
        //    {
        //        MemberId = 3,
        //        Account = "userThree",
        //        Password = "tgm10333",
        //        Name = "NameOfAdmin",
        //        Gender = false,
        //        Birthday = DateTime.Now,
        //        Email = "123@123.com",
        //        EmailComfirmed = true,
        //        Address = "屏東市仁愛路5號",
        //        PhoneNumber = "0876543210",
        //        MobilePhone = "0913579246",
        //        MemberShip = MemberShipType.Admin,
        //        LockOutEnabled = false,
        //        AccessFailedCount = 0,
        //    });

        //    modelBuilder.Entity<Cart>().HasData(new Cart
        //    {
        //        CartId = 3,
        //        MemberId = 2,
        //        ProductId = 6,
        //        Quantity = 2,
        //    });
        //    modelBuilder.Entity<WishList>().HasData(new WishList
        //    {
        //        WishListId = 1,
        //        ProductId = 1,
        //        MemberId = 2
        //    });

        //    // 作者大頭照
        //    modelBuilder.Entity<AuthorImage>().HasData(new AuthorImage
        //    {
        //        Id = 1,
        //        MemberId = 1,
        //        FirstImageFileName = "assets/images/blog/blog-author.png",
        //        SecondImageFileName = "assets/images/blog/blog-author-2.png",
        //    });
        //    modelBuilder.Entity<AuthorImage>().HasData(new AuthorImage
        //    {
        //        Id = 2,
        //        MemberId = 2,
        //        FirstImageFileName = "assets/images/blog/blog-author.png",
        //        SecondImageFileName = "assets/images/blog/blog-author-2.png",
        //    });
        //    modelBuilder.Entity<AuthorImage>().HasData(new AuthorImage
        //    {
        //        Id = 3,
        //        MemberId = 3,
        //        FirstImageFileName = "assets/images/blog/blog-author.png",
        //        SecondImageFileName = "assets/images/blog/blog-author-2.png",
        //    });

        //    // 文章 No. 1
        //    modelBuilder.Entity<Article>().HasData(new Article
        //    {
        //        ArticleId = ++countArticle,
        //        MemberId = 1,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        Title = "Lorem ipsum dolor consectet.",
        //        Content = "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.",
        //    });
        //    modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        Type = ArticleType.LatestBlog,
        //    });
        //    modelBuilder.Entity<ArticleTitleImage>().HasData(new ArticleTitleImage
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details.png",
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-2.png"
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-3.png"
        //    });

        //    // 文章 No. 2
        //    modelBuilder.Entity<Article>().HasData(new Article
        //    {
        //        ArticleId = ++countArticle,
        //        MemberId = 2,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        Title = "Duis et volutpat pellentesque.",
        //        Content = "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.",
        //    });
        //    modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        Type = ArticleType.LatestBlog,
        //    });
        //    modelBuilder.Entity<ArticleTitleImage>().HasData(new ArticleTitleImage
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details.png",
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-2.png"
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-3.png"
        //    });

        //    // 文章 No. 3
        //    modelBuilder.Entity<Article>().HasData(new Article
        //    {
        //        ArticleId = ++countArticle,
        //        MemberId = 3,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        Title = "Vivamus vitae dolor convallis.",
        //        Content = "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.",
        //    });
        //    modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        Type = ArticleType.LatestBlog,
        //    });
        //    modelBuilder.Entity<ArticleTitleImage>().HasData(new ArticleTitleImage
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details.png",
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-2.png"
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-3.png"
        //    });

        //    // 文章 No. 4
        //    modelBuilder.Entity<Article>().HasData(new Article
        //    {
        //        ArticleId = ++countArticle,
        //        MemberId = 3,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        Title = "Vivamus amet tristique orci.",
        //        Content = "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.",
        //    });
        //    modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        Type = ArticleType.LatestBlog,
        //    });
        //    modelBuilder.Entity<ArticleTitleImage>().HasData(new ArticleTitleImage
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details.png",
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-2.png"
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-3.png"
        //    });

        //    // 文章 No. 5
        //    modelBuilder.Entity<Article>().HasData(new Article
        //    {
        //        ArticleId = ++countArticle,
        //        MemberId = 2,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        Title = "Pellentesque pretium place.",
        //        Content = "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.",
        //    });
        //    modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        Type = ArticleType.LatestBlog,
        //    });
        //    modelBuilder.Entity<ArticleTitleImage>().HasData(new ArticleTitleImage
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details.png",
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-2.png"
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-3.png"
        //    });

        //    // 文章 No. 6
        //    modelBuilder.Entity<Article>().HasData(new Article
        //    {
        //        ArticleId = ++countArticle,
        //        MemberId = 1,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        Title = "Sed euismod tristique dolor.",
        //        Content = "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.",
        //    });
        //    modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        Type = ArticleType.LatestBlog,
        //    });
        //    modelBuilder.Entity<ArticleTitleImage>().HasData(new ArticleTitleImage
        //    {
        //        Id = countArticle,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details.png",
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-2.png"
        //    });
        //    modelBuilder.Entity<ArticleContentImage>().HasData(new ArticleContentImage
        //    {
        //        Id = ++countContentImage,
        //        ArticleId = countArticle,
        //        FileName = "assets/images/blog/blog-details-3.png"
        //    });
        //}
    }
}