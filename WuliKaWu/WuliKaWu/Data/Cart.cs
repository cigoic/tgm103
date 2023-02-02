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
=======
        /// <summary>
        /// 購物車 ID (Primary Key , 自動編號)
        /// </summary>
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
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
<<<<<<< HEAD
        public decimal? Coupon { get; set; }
<<<<<<< HEAD

        public decimal Total { get; set; }
>>>>>>> [更新] 資料庫資料表
=======
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
=======
        public virtual Member Member { get; set; }
>>>>>>> [更改]Cart,Member,Order,OrderDetails,Product,Wishlist 的Model
    }
}