using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class ProductEditModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<int> ColorIds { get; set; }
        public Size SizeId { get; set; }
        public int CategoryId { get; set; }
        public List<string> Pictures { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public List<int> TagIds { get; set; }
        public string Comment { get; set; }
    }
}