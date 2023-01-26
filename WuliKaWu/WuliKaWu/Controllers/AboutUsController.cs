using Microsoft.AspNetCore.Mvc;

namespace WuliKaWu.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
