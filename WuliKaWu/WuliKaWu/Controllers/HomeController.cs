using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using WuliKaWu.Models;

namespace WuliKaWu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // TODO: 請整合 about-us.html
        public IActionResult AboutUs()
        {
            return View();
        }

        // TODO: 請整合 blog.html
        public IActionResult Blog()
        {
            return View();
        }

        // TODO: 請整合 blog-details.html
        public IActionResult BlogDetails()
        {
            return View();
        }

        // TODO: 請整合 blog-sidebar.html
        public IActionResult BlogSidebar()
        {
            return View();
        }

        // TODO: 請整合 cart.html
        public IActionResult Cart()
        {
            return View();
        }

        // TODO: 請整合 checkout.html
        [ActionName("Checkout")]
        public IActionResult CheckoutCart()
        {
            return View();
        }

        // TODO: 請整合 compare.html
        [ActionName("Compare")]
        public IActionResult CompareProducts()
        {
            return View();
        }

        // TODO: 請整合 contact-us.html
        public IActionResult ContactUs()
        {
            return View();
        }

        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        // TODO: 請整合 index-2.html
        public IActionResult IndexTwo()
        {
            return View();
        }

        // TODO: 請整合 index-3.html
        public IActionResult IndexThree()
        {
            return View();
        }

        // TODO: 請整合 index-4.html
        public IActionResult IndexFour()
        {
            return View();
        }

        // TODO: 請整合 index-5.html
        public IActionResult IndexFive()
        {
            return View();
        }

        // TODO: 請整合 index-6.html
        public IActionResult IndexSix()
        {
            return View();
        }

        // TODO: 請整合 index-7.html
        public IActionResult IndexSeven()
        {
            return View();
        }

        // TODO: 請整合 index-8.html
        public IActionResult IndexEight()
        {
            return View();
        }

        // TODO: 請整合至 Indentity 控制頁面
        //public IActionResult LoginRegister()
        //{
        //    return View();
        //}

        // TODO: 請整合 my-account.html
        public IActionResult MyAccount()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// 產品資訊 1
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductDetails()
        {
            return View();
        }

        // TODO: 請整合 product-details-2.html
        public IActionResult ProductDetailsTwo()
        {
            return View();
        }

        // TODO: 請整合 product-details-affiliate.html
        public IActionResult ProductDetailsAffiliate()
        {
            return View();
        }

        // TODO: 請整合 product-details-fixed-img.html
        public IActionResult ProductDetailsFixedImg()
        {
            return View();
        }

        // TODO: 請整合 product-details-gallery.html
        public IActionResult ProductDetailsGallery()
        {
            return View();
        }

        // TODO: 請整合 product-details-group.html
        public IActionResult ProductDetailsGroup()
        {
            return View();
        }

        // TODO: 請整合 shop.html
        public IActionResult Shop()
        {
            return View();
        }

        // TODO: 請整合 shoplist.html
        public IActionResult ShopList()
        {
            return View();
        }

        // TODO: 請整合 shop-list-sidebar.html
        public IActionResult ShopListSidebar()
        {
            return View();
        }

        // TODO: 請整合 shop-location.html
        public IActionResult ShopLocation()
        {
            return View();
        }

        // TODO: 請整合 shop-right-sidebar.html
        public IActionResult ShopRightSidebar()
        {
            return View();
        }

        // TODO: 請整合 shop-sidebar.html
        public IActionResult ShopSidebar()
        {
            return View();
        }

        // TODO: 請整合 wishlist.html
        public IActionResult WishList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}