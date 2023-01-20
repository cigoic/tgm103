<<<<<<< HEAD
﻿using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;
=======
﻿using static WuliKaWu.Data.Enums.Common;
>>>>>>> 新增CartController及CartApiController

namespace WuliKaWu.Models.ApiModel
{
    public class CartModel
    {
        public int CartId { get; set; }
<<<<<<< HEAD
        public int ProductId { get; set; }
        public int MemberId { get; set; }
=======
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public int Quantity { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public decimal? Coupon { get; set; }
<<<<<<< HEAD
        public decimal Total { get; set; }
>>>>>>> 新增CartController及CartApiController
=======
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
    }
}