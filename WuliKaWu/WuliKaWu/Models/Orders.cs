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
        public int Amount { get; set; }
        public int UnitPrice { get; set; }
        public float? Discount { get; set; }
        public string ShippingAddress { get; set; }

        public enum GetPayType
        { Cash, CreditCard, MoblilePay }

        public string? Memo { get; set; }
        public int TotalPrice { get; set; }
    }
}