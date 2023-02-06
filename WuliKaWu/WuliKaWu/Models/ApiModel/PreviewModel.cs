using System.ComponentModel.DataAnnotations;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class PreviewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Color Color { get; set; }

        public string Size { get; set; }

        public string Category { get; set; }

        public string PicturePath { get; set; }

        public decimal Price { get; set; }

        public bool? Discount { get; set; }

        public string? SellingPrice { get; set; }

        public Tag? Tag { get; set; }
    }
}