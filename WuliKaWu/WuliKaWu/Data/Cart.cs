using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Cart")]
    public class Cart
    {
        /// <summary>
        /// 購物車 ID (Primary Key , 自動編號)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 關聯的商品ID (Foreign Key)
        /// </summary>

        public int ProductId { get; set; }

        /// <summary>
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 導覽屬性:一個購物車對應到多個商品，用 ICollection
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// 導覽屬性:對應到單一個會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
    }
}