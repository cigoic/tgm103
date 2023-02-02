using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    //[Table("WishLists")]
    public class WishList
    {
        /// <summary>
        /// 願望清單ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListId { get; set; }

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
        /// 商品名稱，最大 nvarchar(max)
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品折扣價格
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// 商品折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 商品圖片位址，最大 nvarchar(max)
        /// </summary>
        public string PicturePath { get; set; }
    }
}