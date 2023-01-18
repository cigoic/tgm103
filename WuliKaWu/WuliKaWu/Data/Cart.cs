using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
=======
using static WuliKaWu.Data.Enums.Common;
>>>>>>> [更新] 資料庫資料表

namespace WuliKaWu.Data
{
    [Table("Cart")]
    public class Cart
    {
<<<<<<< HEAD
        /// <summary>
        /// 購物車 ID (Primary Key , 自動編號)
        /// </summary>
        [Key]
        public int Id { get; set; }

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
=======
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Coupon { get; set; }

        public decimal Total { get; set; }
>>>>>>> [更新] 資料庫資料表
    }
}