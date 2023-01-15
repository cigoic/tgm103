using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu
{
    public class WishList
    {
        public int MemberID
        {
            get => default;
            set
            {
            }
        }

        public int ProductID
        {
            get => default;
            set
            {
            }
        }

        public int UnitPrice
        {
            get => default;
            set
            {
            }
        }

        public int Unit
        {
            get => default;
            set
            {
            }
        }

        public int Qty
        {
            get => default;
            set
            {
            }
        }

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListID
        {
            get => default;
            set
            {
            }
        }
    }
}