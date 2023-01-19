using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    public class WishList
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListId { get; set; }

        [ForeignKey("Members")]
        public int MemberId { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Discount { get; set; }
        public string Picture { get; set; }
    }
}