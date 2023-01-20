﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD

=======
>>>>>>> [更新] 資料庫資料表
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Products")]
    public class Product
    {
<<<<<<< HEAD
        /// <summary>
        /// 商品 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名稱，最大長度50
        /// </summary>
        [StringLength(50)]
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品尺寸類型值
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品折扣價格，可為NULL
        /// </summary>
        public decimal? SellingPrice { get; set; }

        /// <summary>
        /// 商品評價，最大 nvarchar(max)，可為NULL
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// 商品分類，不可為NULL
        /// </summary>
        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品顏色，用 ICollection
        /// </summary>
        public virtual ICollection<Color> Colors { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品星等，用 ICollection
        /// </summary>
        public virtual ICollection<StarRate> StarRates { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品標籤，用 ICollection
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到單一個商品分類，不用 ICollection
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// 導覽屬性:一個商品對應到多個商品圖片，用 ICollection
        /// </summary>
        public virtual ICollection<Picture> Pictures { get; set; }

        /// <summary>
        /// 導覽屬性:對應多個購物車,使用 ICollection
        /// </summary>
        public virtual ICollection<Cart> Cart { get; set; }

        /// <summary>
        /// 導覽屬性:對應多個收藏清單,使用 ICollection
        /// </summary>
        public virtual ICollection<WishList> WishList { get; set; }
=======
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? Discount { get; set; }

        public string? Comment { get; set; }

        public StarRate? StarRate { get; set; }

        public Category Category { get; set; }

        public Tag? Tag { get; set; }
<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======

        public virtual ICollection<TableOfSize> TableOfSizes { get; set; }

        public virtual ICollection<TableOfColor> TableOfColors { get; set; }

        public virtual ICollection<TableOfStarRate> TableOfStarRates { get; set; }

        public virtual ICollection<TableOfCategory> TableOfCategories { get; set; }

        public virtual ICollection<TableOfTag> TableOfTags { get; set; }
>>>>>>> [新增]所有資料表
    }
}