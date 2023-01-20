using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// 商品 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品名稱，最大長度50
        /// </summary>
        [StringLength(50)]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品顏色類型值
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 商品尺寸類型值
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// 商品圖片位址，最大 nvarchar(max)
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品折扣價格
        /// </summary>
        public decimal? SellingPrice { get; set; }

<<<<<<< HEAD
        public decimal? Discount { get; set; }
=======
        /// <summary>
        /// 商品折扣，可為NULL
        /// </summary>
        public decimal? discount { get; set; }
>>>>>>> 5794faa38d9b346344c2e29639d3570b0044c8e8

        /// <summary>
        /// 商品評價，最大 nvarchar(max)，可為NULL
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// 商品星等，可為NULL
        /// </summary>
        public StarRate? StarRate { get; set; }

        /// <summary>
        /// 商品分類，可為NULL
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// 商品標籤，可為NULL
        /// </summary>
        public Tag? Tag { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品尺寸，用 ICollection
        /// </summary>
        public virtual ICollection<TableOfSize> TableOfSizes { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品顏色，用 ICollection
        /// </summary>
        public virtual ICollection<TableOfColor> TableOfColors { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品星等，用 ICollection
        /// </summary>
        public virtual ICollection<TableOfStarRate> TableOfStarRates { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品分類，用 ICollection
        /// </summary>
        public virtual ICollection<TableOfCategory> TableOfCategories { get; set; }

        /// <summary>
        /// 導覽屬性：一個商品對應到多個商品標籤，用 ICollection
        /// </summary>
        public virtual ICollection<TableOfTag> TableOfTags { get; set; }
    }
}