using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
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
=======
namespace MVCNetFramework
{
    public class WishList
    {
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
        public int MemberID
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
        [ForeignKey("Products")]
=======
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
        public int ProductID
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
        public string ProductName
=======
        public int UnitPrice
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
        public decimal Price
=======
        public int Unit
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
        public decimal SellingPrice
=======
        public int Qty
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
        public decimal Discount
=======
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListID
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
        {
            get => default;
            set
            {
            }
        }

<<<<<<< HEAD
        public string Picture
=======
        public Product Product
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
        {
            get => default;
            set
            {
            }
        }
    }
}