using System.ComponentModel.DataAnnotations;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class ProductModel
    {

        public string ProductName { get; set; }

        public List<int> Color { get; set; }

        public List<int> Size { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string SellingPrice { get; set; }

        public List<IFormFile> PictureFiles { get; set; }
        public List<int> Tag { get; set; }
        public string Comment { get; set; }
    }
}