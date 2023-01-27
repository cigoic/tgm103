using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    //TODO OrderDetails名稱須更正,該怎麼更改並更新資料庫
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailsId { get; set; }

        /// <summary>
        /// 訂單 ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 產品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
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
        public string PicturePath { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品折扣價格
        /// </summary>
        public decimal? SellingPrice { get; set; }

        // <summary>
        /// 商品折扣
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
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
        public GetPayType Type { get; set; }
    }
}