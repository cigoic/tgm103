using System.ComponentModel.DataAnnotations;

namespace WuliKaWu.Models.ApiModel
{
    public class ProductModel
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public int Price { get; set; }
        public string ImagePath { get; set; }
        public bool Discount { get; set; }
        public string SellingPrice { get; set; }

    }
}
