using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CheckOutDetailModel
    {
        public int CheckOutId { get; set; }
        public int MemberId { get; set; }
        public GetPayType Type { get; set; }

        //public decimal? Coupon { get; set; }
        public string ShippingAddress { get; set; }

        public string Recipient { get; set; }
        public string ContactPhone { get; set; }
        public string? Memo { get; set; }

        /// <summary>
        /// 下定日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        public DateTime ShippingDate { get; set; }

        /// <summary>
        /// 出貨狀態
        /// </summary>
        public ShippingStatus Status { get; set; }

        ///// <summary>
        ///// 商品名稱
        ///// </summary>
        //public string ProductName { get; set; }

        ///// <summary>
        ///// 商品顏色
        ///// </summary>
        //public Data.Color Color { get; set; }

        ///// <summary>
        ///// 商品尺寸
        ///// </summary>
        //public Size Size { get; set; }

        ///// <summary>
        ///// 商品圖片位址
        ///// </summary>
        //public string PicturePath { get; set; }

        ///// <summary>
        ///// 商品折扣價格，可為NULL
        ///// </summary>
        //public decimal? SellingPrice { get; set; }

        ///// <summary>
        ///// 商品價格
        ///// </summary>
        //public decimal Price { get; set; }

        ///// <summary>
        ///// 商品數量
        ///// </summary>
        //public int Quantity { get; set; }
    }
}