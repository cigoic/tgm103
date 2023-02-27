using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class ProductEditModel
    {
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public string ProductName { get; set; }
        public List<int> Colors { get; set; }
        public Size Size { get; set; }
        public int CategoryName { get; set; }
        public List<IFormFile>? Pictures { get; set; }
        public List<string>? DeletePictures { get; set; }

        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public List<int> Tags { get; set; }
        public string Comment { get; set; }
    }
}