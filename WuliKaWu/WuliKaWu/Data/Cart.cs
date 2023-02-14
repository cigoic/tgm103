using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Carts")]
    public class Cart
    {
        /// <summary>
        /// 購物車 ID (Primary Key , 自動編號)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Member")]
        public int MemberId { get; set; }

        /// <summary>
        /// 關聯的商品ID (Foreign Key)
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// 導覽屬性:只對應一個商品，不用 ICollection
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 導覽屬性:只對應到一個會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
    }
}