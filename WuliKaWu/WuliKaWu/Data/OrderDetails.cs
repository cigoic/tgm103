using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    //TODO OrderDetails名稱須更正,該怎麼更改並更新資料庫
    [Table("OrderDetails")]
<<<<<<< HEAD
    public class OrderDetails
    {
        [Key]
=======
using System.Drawing;
=======
using static WuliKaWu.Data.Enums.Common;
>>>>>>> [新增]CheckOut table的ApiModel[修改]原Picture改成PicturePath

namespace WuliKaWu.Data
{
    //TODO OrderDetails名稱須更正,該怎麼更改並更新資料庫
    [Table("OderDetails")]
=======
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
    public class OrderDetails
    {
        [Key]
<<<<<<< HEAD
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
=======
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
        public int OrderDetailsId { get; set; }

        /// <summary>
        /// 訂單 ID
        /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD

        public int OrderId { get; set; }

        /// <summary>
=======
        public int OrderId { get; set; }
=======
>>>>>>> [更改]Cart,Member,Order,OrderDetails,Product,Wishlist 的Model

        public int OrderId { get; set; }

        /// <summary>
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
        /// 商品名稱
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品顏色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 商品尺寸
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// 商品圖片位址
        /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD
        public string PicturePath { get; set; }
=======
        public string Picture { get; set; }
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
=======
        public string PicturePath { get; set; }
>>>>>>> [新增]CheckOut table的ApiModel[修改]原Picture改成PicturePath

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
        /// <summary>
<<<<<<< HEAD
        /// 商品折扣價格
        /// </summary>
        public decimal? SellingPrice { get; set; }

>>>>>>> [新增]CheckOut table的ApiModel[修改]原Picture改成PicturePath
        // <summary>
        /// 商品折扣
        /// </summary>
        public decimal? Discount { get; set; }

>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
        /// <summary>
=======
>>>>>>> [更改]Cart,Member,Order,OrderDetails,Product,Wishlist 的Model
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
<<<<<<< HEAD
<<<<<<< HEAD
        /// 導覽屬性：只對應到單一訂單，不用 ICollection
        /// </summary>
        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
=======
        /// 優惠券
        /// </summary>
        public decimal? Coupon { get; set; }

        /// <summary>
        /// 收件人，最大長度 24
        /// </summary>
        [MaxLength(24)]
        public string Recipient { get; set; }

        /// <summary>
        /// 收件地址，最大長度 100
        /// </summary>
        [MaxLength(100)]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 收件人電話
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
<<<<<<< HEAD
        public TableOfGetPayType TableOfGetPayTypes { get; set; }
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
=======
        public GetPayType Type { get; set; }
>>>>>>> [修改]支付方式的型態
=======
        /// 導覽屬性：只對應到單一訂單，不用 ICollection
        /// </summary>
        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
>>>>>>> [更改]Cart,Member,Order,OrderDetails,Product,Wishlist 的Model
    }
}