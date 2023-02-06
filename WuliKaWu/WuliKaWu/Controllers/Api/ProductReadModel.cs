using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Controllers.Api
{
    public class ProductReadModel
    {
        public bool Discount { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public string? Comment { get; set; }
        public int CategoryId { get; set; }
        public  List<int> Colors { get; set; }
        public  int StarRates { get; set; }
        public  List<int> Tags { get; set; }
        public  List<string> Pictures { get; set; }
    }
}
