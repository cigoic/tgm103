<<<<<<< HEAD
<<<<<<< HEAD
﻿using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;
=======
﻿using static WuliKaWu.Data.Enums.Common;
>>>>>>> 新增CartController及CartApiController
=======
﻿using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;
>>>>>>> [修正] 更動資料表後的 Cart, whishlist 檢視與控制器程式片段

namespace WuliKaWu.Models.ApiModel
{
    public class CartModel
    {
        public int CartId { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public int ProductId { get; set; }
        public int MemberId { get; set; }
=======
        public string ProductName { get; set; }
        public string PicturePath { get; set; }
        public decimal Price { get; set; }
        public string? SellingPrice { get; set; }
        public int Quantity { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public decimal? Coupon { get; set; }
<<<<<<< HEAD
        public decimal Total { get; set; }
>>>>>>> 新增CartController及CartApiController
=======
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
=======
        public Product Product { get; set; }
<<<<<<< HEAD
        //public string ProductName { get; set; }
        //public string PicturePath { get; set; }
        //public decimal Price { get; set; }
        //public string? SellingPrice { get; set; }
        //public int Quantity { get; set; }
        //public Size Size { get; set; }
        //public Color Color { get; set; }
        //public decimal? Coupon { get; set; }
>>>>>>> [修正] 更動資料表後的 Cart, whishlist 檢視與控制器程式片段
=======
>>>>>>> [新增]Cartapicontroller Getcart Action及Wishlistcontroller Addtocart Action
=======
        public int ProductId { get; set; }
<<<<<<< HEAD
>>>>>>> [修改]Gettocart及Getwishlist
=======
        public int MemberId { get; set; }
>>>>>>> [修改]Addtocart Action
    }
}