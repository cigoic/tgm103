using Microsoft.AspNetCore.Mvc;

namespace WuliKaWu.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}