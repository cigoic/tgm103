<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
=======
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 更新類別圖
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

<<<<<<< HEAD
namespace MVCNetFramework
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
namespace WuliKaWu.Data
>>>>>>> 更新類別圖
{
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// 商品 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
=======
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> 更新類別圖
=======
>>>>>>> [修改]調整類別圖
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public string Picture { get; set; }

        public decimal Price { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? discount { get; set; }

        public string? Comment { get; set; }

        public StarRate? StarRate { get; set; }

        public Category Category { get; set; }

        public Tag? Tag { get; set; }
=======
        public byte[] Picture { get; set; }
=======
        public string Picture { get; set; }
>>>>>>> 更新類別圖

=======
        /// <summary>
        /// 商品價格
        /// </summary>
>>>>>>> [修改]調整類別圖
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

<<<<<<< HEAD
<<<<<<< HEAD
    public enum Tag
    {
        Hot, New, Spring, Winter
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        public Tag? Tag { get; set; }
>>>>>>> 更新類別圖
=======
        /// <summary>
        /// 導覽屬性:對應多個收藏清單,使用 ICollection
        /// </summary>
        public virtual ICollection<WishList> WishList { get; set; }
>>>>>>> [修改]調整類別圖
    }
}