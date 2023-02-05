using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> [更新] 資料庫資料表
=======

>>>>>>> [更新] 修正 Product.cs 中版本衝突合併的段落
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Products")]
    public class Product
    {
<<<<<<< HEAD
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
=======
        /// <summary>
        /// 商品 ID (Primary Key, 自動編號)
        /// </summary>
>>>>>>> [更新]商品相關表格及願望清單表格加入summary
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
<<<<<<< HEAD
        /// 商品折扣，可為NULL
        /// </summary>
<<<<<<< HEAD
        public decimal? discount { get; set; }
>>>>>>> [更新]商品相關表格及願望清單表格加入summary
=======
        public decimal? Discount { get; set; }
>>>>>>> 修改衝突Product Table中Discount

        /// <summary>
=======
>>>>>>> 暫時修改
        /// 商品評價，最大 nvarchar(max)，可為NULL
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// 商品星等，可為NULL
        /// </summary>
        public StarRate? StarRate { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// 商品分類
=======
=======
>>>>>>> 暫時修改
        /// 商品分類，不可為NULL
>>>>>>> [更新]Enum/Product/Member表格
        /// </summary>
<<<<<<< HEAD
        public Category Category { get; set; }

        /// <summary>
        /// 商品標籤，可為NULL
        /// </summary>
        public Tag? Tag { get; set; }
<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======
=======
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
>>>>>>> 暫時修改


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
<<<<<<< HEAD
<<<<<<< HEAD
        public virtual ICollection<TableOfTag> TableOfTags { get; set; }
<<<<<<< HEAD
>>>>>>> [新增]所有資料表
=======
=======
        public virtual TableOfCategory TableOfCategories { get; set; }
>>>>>>> [更新]Enum/Product/Member表格
=======
        public virtual Category Category { get; set; }
>>>>>>> 暫時修改

        /// <summary>
        /// 導覽屬性:一個商品對應到多個商品圖片，用 ICollection
        /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD
        public virtual ICollection<Picture> Pictures { get; set; }
>>>>>>> [新增] 商品圖片表並且在商品表加上商品圖片導覽屬性
=======
        public virtual Picture Pictures { get; set; }
>>>>>>> [更新]Enum/Product/Member表格
=======
        public virtual ICollection<Picture> Pictures { get; set; }

        /// <summary>
        /// 導覽屬性:只對應到單一個購物車,不用 ICollection
        /// </summary>
        public virtual ICollection<Cart> Cart { get; set; }

        /// <summary>
        /// 導覽屬性:只對應到單一個收藏清單,不用 ICollection
        /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD
        public virtual WishList WishList { get; set; }
>>>>>>> [更改]Cart,Member,Order,OrderDetails,Product,Wishlist 的Model
=======
        public virtual WishList? WishList { get; set; }
>>>>>>> [更新] ShopContext 等資料內容定義類別表
=======
        public virtual ICollection<WishList> WishList { get; set; }
>>>>>>> 暫時修改
    }
}