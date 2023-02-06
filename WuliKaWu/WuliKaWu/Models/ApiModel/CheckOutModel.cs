using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CheckOutModel
    {
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
        public int Quantity { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
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
        public decimal? Coupon { get; set; }
    }
}