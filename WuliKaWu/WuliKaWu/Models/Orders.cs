using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public float? CouponDiscount { get; set; }
        public string ShippingAddress { get; set; }

        public enum GetPayType
        { Cash, CreditCard, MoblilePay }

        public string? Memo { get; set; }

        public virtual ICollection<CartViewModel> Cart { get; set; }
    }
}