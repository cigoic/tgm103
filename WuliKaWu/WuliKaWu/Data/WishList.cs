using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
<<<<<<< HEAD
    [Table("WishLists")]
    public class WishList
    {
        /// <summary>
        /// 願望清單ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        public int WishListId { get; set; }

        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 關聯的商品ID
        /// </summary>
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        /// <summary>
        /// 導覽屬性:對應多個會員，使用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 導覽屬性:對應多筆商品，使用 ICollection
        /// </summary>

        public virtual Product Product { get; set; }
=======
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
>>>>>>> [更新] 資料庫資料表
    }
}