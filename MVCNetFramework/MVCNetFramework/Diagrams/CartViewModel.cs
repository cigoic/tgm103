using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCNetFramework
{
    [Table("Cart")]
    public class CartViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(32)]
        public string Conutry { get; set; }

        [StringLength(32)]
        public string State { get; set; }

        [StringLength(32)]
        public string City { get; set; }

        [StringLength(32)]
        public string PostalCode { get; set; }

        [ForeignKey("Products")]
        public byte[] Picture { get; set; }

        [StringLength(64)]
        public string ProductName { get; set; }

        [ForeignKey("Orders")]
        public int Price { get; set; }

        public int Quantity { get; set; }
        public float CouponDiscount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Orders Orders { get; set; }

        public Product Product1
        {
            get => default;
            set
            {
            }
        }
    }
}