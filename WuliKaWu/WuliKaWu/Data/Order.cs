using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? CouponDiscount { get; set; }

        public string ShippingAddress { get; set; }

        public string? Memo { get; set; }

        public virtual ICollection<TableOfGetPayType> TableOfGetPayTypes { get; set; }
    }
}