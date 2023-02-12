using WuliKaWu.Data;

namespace WuliKaWu.Models.ApiModel
{
    public class WishListGetModel
    {
        public int WishListId { get; set; }
        public string ProductName { get; set; }
        public bool Discount { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public List<string> PicturePath { get; set; }
    }
}