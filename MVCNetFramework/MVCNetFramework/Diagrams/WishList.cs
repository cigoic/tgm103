using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
<<<<<<< HEAD
namespace WuliKaWu.Data
{
    [Table("WishLists")]
    public class WishList
    {
<<<<<<< HEAD
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
=======
namespace MVCNetFramework
{
    public class WishList
    {
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
namespace WuliKaWu.Data
{
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
>>>>>>> 更新類別圖
        public int MemberID
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        [ForeignKey("Products")]
=======
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        [ForeignKey("Products")]
>>>>>>> 更新類別圖
        public int ProductID
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public string ProductName
=======
        public int UnitPrice
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        public string ProductName
>>>>>>> 更新類別圖
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public decimal Price
=======
        public int Unit
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        public decimal Price
>>>>>>> 更新類別圖
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public decimal SellingPrice
=======
        public int Qty
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        public decimal SellingPrice
>>>>>>> 更新類別圖
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public decimal Discount
=======
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListID
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        public decimal Discount
>>>>>>> 更新類別圖
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public string Picture
=======
        public Product Product
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        public string Picture
>>>>>>> 更新類別圖
        {
            get => default;
            set
            {
            }
        }
=======
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
>>>>>>> [修改]調整類別圖
    }
}