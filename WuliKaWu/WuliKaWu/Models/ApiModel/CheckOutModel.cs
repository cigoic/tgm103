using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CheckOutModel
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public int CheckOutId { get; set; }
=======
>>>>>>> [新增]CheckOut table的ApiModel[修改]原Picture改成PicturePath
=======
        public int CheckOutId { get; set; }
>>>>>>> [新增] Add-migration checkoutmodel的checkoutid
        public string ShippingAddress { get; set; }
        public string Recipient { get; set; }
        public string ContactPhone { get; set; }
        public string PicturePath { get; set; }
        public string ProductName { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public List<string> Colors { get; set; }
=======
        public Color Color { get; set; }
>>>>>>> [新增]CheckOut table的ApiModel[修改]原Picture改成PicturePath
=======
        public List<string> Colors { get; set; }
>>>>>>> DB修改
=======
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MemberId { get; set; }
        public List<string> PicturePath { get; set; }
        public string ProductName { get; set; }
        public List<string> Type { get; set; }
>>>>>>> [修改]_layout 修改checkout路徑
        public int Quantity { get; set; }
        public string Size { get; set; }
        public bool Discount { get; set; }
        public decimal Price { get; set; }
<<<<<<< HEAD
        public string? SellingPrice { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public GetPayType Type { get; set; }
=======
        public TableOfGetPayType TableOfGetPayTypes { get; set; }
>>>>>>> [新增]CheckOut table的ApiModel[修改]原Picture改成PicturePath
=======
        public GetPayType Type { get; set; }
>>>>>>> [修改]支付方式的型態
=======
        public decimal? SellingPrice { get; set; }
<<<<<<< HEAD
        public GetPayType GetPayType { get; set; }
>>>>>>> [修改]_layout 修改checkout路徑
        public decimal? Coupon { get; set; }
        public string ShippingAddress { get; set; }
        public string Recipient { get; set; }
        public string ContactPhone { get; set; }
=======
>>>>>>> [新增]CheckoutApiController及CheckoutDetailModel、CheckoutModel
    }
}