using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Coupon { get; set; }

        public decimal Total { get; set; }
    }
}