using System.ComponentModel.DataAnnotations;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public bool Discount { get; set; }

        public string SellingPrice { get; set; }

        public Category Category { get; set; }

        public Tag Tag { get; set; }
    }
}