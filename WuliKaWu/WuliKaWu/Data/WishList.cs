using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
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
        public virtual ICollection<Member> Member { get; set; }

        /// <summary>
        /// 導覽屬性:對應多筆商品，使用 ICollection
        /// </summary>

        public virtual ICollection<Product> Product { get; set; }
    }
}