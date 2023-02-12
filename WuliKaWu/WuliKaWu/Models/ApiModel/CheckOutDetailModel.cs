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
    }
}