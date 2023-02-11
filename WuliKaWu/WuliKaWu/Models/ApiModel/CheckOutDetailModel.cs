using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CheckOutDetailModel
    {
        public int CheckOutId { get; set; }
        public int MemberId { get; set; }
        public GetPayType Type { get; set; }
        public decimal? Coupon { get; set; }
        public string ShippingAddress { get; set; }
        public string Recipient { get; set; }
        public string ContactPhone { get; set; }
        public string? Memo { get; set; }
    }
}