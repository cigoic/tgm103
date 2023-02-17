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
        [ForeignKey("Member")]
        public int MemberId { get; set; }

        /// <summary>
        /// 關聯的商品ID
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// 導覽屬性:只對應一個會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 導覽屬性:只對應一筆商品，不用 ICollection
        /// </summary>

        public virtual Product Product { get; set; }
    }
}