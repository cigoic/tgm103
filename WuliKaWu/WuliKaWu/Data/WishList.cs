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

<<<<<<< HEAD
<<<<<<< HEAD
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
=======
=======
        /// <summary>
        /// 商品名稱，最大 nvarchar(max)
        /// </summary>
>>>>>>> [更新]商品相關表格及願望清單表格加入summary
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
<<<<<<< HEAD
        public string Picture { get; set; }
>>>>>>> 新增WishListTable及Api
=======
        public string PicturePath { get; set; }
>>>>>>> [新增]CheckOut table的ApiModel[修改]原Picture改成PicturePath
    }
}