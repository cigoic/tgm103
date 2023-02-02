﻿using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CartModel
    {
        public int CartId { get; set; }
        public Product Product { get; set; }
        //public string ProductName { get; set; }
        //public string PicturePath { get; set; }
        //public decimal Price { get; set; }
        //public string? SellingPrice { get; set; }
        //public int Quantity { get; set; }
        //public Size Size { get; set; }
        //public Color Color { get; set; }
        //public decimal? Coupon { get; set; }
    }
}