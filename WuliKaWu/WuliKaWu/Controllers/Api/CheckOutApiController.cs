<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
=======
﻿using Microsoft.AspNetCore.Http;
>>>>>>> [調整]更改檔案位子至Api
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/checkout/[action]")]
    [ApiController]
    public class CheckOutApiController : ControllerBase
    {
<<<<<<< HEAD
<<<<<<< HEAD
        private readonly ShopContext _context;

        public CheckOutApiController(ShopContext context)
        {
            _context = context;
=======
        private readonly ShopContext _db;

        public CheckOutApiController(ShopContext context)
        {
            _db = context;
>>>>>>> [調整]更改檔案位子至Api
=======
        private readonly ShopContext _context;

        public CheckOutApiController(ShopContext context)
        {
            _context = context;
>>>>>>> [新增]AddWishList Action 及 AddToCart Action
        }

        public List<CheckOutModel> GetAll()
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            throw new NotImplementedException();
            //return _context.Carts.Select(x => new CheckOutModel
            //{
            //    CheckOutId = 2,
            //    PicturePath = "/assets/images/cart/cart-2.jpg",
            //    ProductName = x.Product.ProductName,
            //    Colors = x.Product.Colors.Select(x=> x.Type).ToList(),
            //    Quantity = x.Quantity,
            //    Size = x.Product.Size,
            //    Price = x.Product.Price,
            //    SellingPrice = x.Product.SellingPrice.ToString() ?? "",
            //    //Coupon = x.Product.Coupon,
            //    Type = (Data.Enums.Common.GetPayType)2,
            //    ShippingAddress = "台北市中山區南京西路1號",
            //    Recipient = "胖虎",
            //    ContactPhone = "0900 123 456"
            //}).ToList();

=======
            return _db.OrderDetails.Select(x => new CheckOutModel
=======
            return _db.Carts.Select(x => new CheckOutModel
>>>>>>> [修改]CheckOutApiController的GetAll() ,原Model為OrderDetails更改為Cart
=======
            return _context.Carts.Select(x => new CheckOutModel
>>>>>>> [新增]AddWishList Action 及 AddToCart Action
            {
                CheckOutId = 2,
                PicturePath = "/assets/images/cart/cart-2.jpg",
<<<<<<< HEAD
                ProductName = x.Product.ProductName,
                Colors = x.Product.Colors.Select(x=> x.Type).ToList(),
                Quantity = x.Quantity,
                Size = x.Product.Size,
                Price = x.Product.Price,
                SellingPrice = x.Product.SellingPrice.ToString() ?? "",
=======
                //ProductName = x.Product.ProductName,
                //Color = x.Product.Color,
                //Quantity = x.Quantity,
                //Size = x.Product.Size,
                //Price = x.Product.Price,
                //SellingPrice = x.Product.SellingPrice.ToString() ?? "",
>>>>>>> [修改]Gettocart及Getwishlist
                //Coupon = x.Product.Coupon,
                Type = (Data.Enums.Common.GetPayType)2,
                ShippingAddress = "台北市中山區南京西路1號",
                Recipient = "胖虎",
                ContactPhone = "0900 123 456"
            }).ToList();
>>>>>>> [調整]更改檔案位子至Api
        }
    }
}