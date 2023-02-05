using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Cart")]
    public class Cart
    {
        /// <summary>
        /// 購物車 ID (Primary Key , 自動編號)
        /// </summary>
        [Key]
        public int CartId { get; set; }

        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 關聯的商品ID (Foreign Key)
        /// </summary>
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 導覽屬性:對應多個商品，使用 ICollection
        /// </summary>
        public virtual ICollection<Product> Product { get; set; }

        /// <summary>
        /// 導覽屬性:對應到多個會員，使用 ICollection
        /// </summary>
        public virtual ICollection<Member> Member { get; set; }
    }
}