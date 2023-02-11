using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class ProductDeleteModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<int> Colors { get; set; }
        public Size Size { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public List<string> Pictures { get; set; }
        public List<int> Tags { get; set; }
        public string Comment { get; set; }
    }
}