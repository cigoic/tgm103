namespace WuliKaWu.Models.ApiModel
{
    public class ProductAddModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<int> ColorIds { get; set; }
        public int SizeId { get; set; }
        public decimal? SellingPrice { get; set; }
        public string Comment { get; set; }
        public List<int> TagIds { get; set; }
        public List<IFormFile> Pictures { get; set; }
    }
}
