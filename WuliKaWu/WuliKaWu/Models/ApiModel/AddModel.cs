using static WuliKaWu.Data.Enums.Common;
using System.ComponentModel.DataAnnotations;

namespace WuliKaWu.Models.ApiModel
{
    public class AddModel
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public string PicturePath { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public decimal? SellingPrice { get; set; }

        public string Category { get; set; }

        public Tag? Tag { get; set; }
    }
}