using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CheckOutModel
    {
        public int CheckOutId { get; set; }
        public string ShippingAddress { get; set; }
        public string Recipient { get; set; }
        public string ContactPhone { get; set; }
        public string PicturePath { get; set; }
        public string ProductName { get; set; }
        public List<string> Colors { get; set; }
        public int Quantity { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
        public string? SellingPrice { get; set; }
        public GetPayType Type { get; set; }
        public decimal? Coupon { get; set; }
    }
}