using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CheckOutModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public List<string> PicturePath { get; set; }
        public string ProductName { get; set; }
        public List<string> Type { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public GetPayType GetPayType { get; set; }
        public decimal? Coupon { get; set; }
        public string ShippingAddress { get; set; }
        public string Recipient { get; set; }
        public string ContactPhone { get; set; }
    }
}