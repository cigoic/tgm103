using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
<<<<<<< HEAD

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    //TODO OrderDetails名稱須更正,該怎麼更改並更新資料庫
    [Table("OrderDetails")]
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
    [Table("OderDetails")]
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
        public int OrderDetailsId { get; set; }

        /// <summary>
        /// 訂單 ID
        /// </summary>
<<<<<<< HEAD

        public int OrderId { get; set; }

        /// <summary>
=======
        public int OrderId { get; set; }

        /// <summary>
        /// 產品ID
        /// </summary>
        public int ProductId { get; set; }

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
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
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
        public TableOfGetPayType TableOfGetPayTypes { get; set; }
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
    }
}