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
        public IEnumerable<List<string>> PicturePath { get; set; }
        public IEnumerable<Common.Size> Size { get; set; }
        public IEnumerable<ICollection<Color>> Color { get; set; }
        public int Quantity { get; set; }
    }
}