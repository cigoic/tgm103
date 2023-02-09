using WuliKaWu.Data;
using WuliKaWu.Data.Enums;

namespace WuliKaWu.Models.ApiModel
{
    public class CartGetModel
    {
        /// <summary>
        /// 購物車 ID
        /// </summary>
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public List<string> PicturePath { get; set; }
        public string Size { get; set; }
        public List<string> Type { get; set; }
        public int Quantity { get; set; }
    }
}