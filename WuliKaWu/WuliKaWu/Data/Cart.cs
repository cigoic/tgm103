using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Cart")]
    public class Cart
    {
        /// <summary>
        /// 購物車 ID (Primary Key , 自動編號)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        /// <summary>
        /// 商品名稱，最大長度 50
        /// </summary>
        [StringLength(50)]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品尺寸
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// 商品顏色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 商品圖片位址
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品折扣價格
        /// </summary>
        public decimal? SellingPrice { get; set; }

        /// <summary>
        /// 商品折扣
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// 優惠券
        /// </summary>
        public decimal? Coupon { get; set; }
    }
}