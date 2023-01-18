using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    public class WishList
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListID
        {
            get => default;
            set
            {
            }
        }

        [ForeignKey("Members")]
        public int MemberID
        {
            get => default;
            set
            {
            }
        }

        [ForeignKey("Products")]
        public int ProductID
        {
            get => default;
            set
            {
            }
        }

        public string ProductName
        {
            get => default;
            set
            {
            }
        }

        public decimal Price
        {
            get => default;
            set
            {
            }
        }

        public decimal SellingPrice
        {
            get => default;
            set
            {
            }
        }

        public decimal Discount
        {
            get => default;
            set
            {
            }
        }

        public string Picture
        {
            get => default;
            set
            {
            }
        }
    }
}