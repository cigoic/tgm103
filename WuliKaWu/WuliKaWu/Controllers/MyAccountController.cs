using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Xml.Linq;

using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly ShopContext _context;

        public MyAccountController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AccountDetailsAsync([Bind("FirstName, LastName, DisplayName, Email, CurrentPwd, NewPwd, ConfirmPwd")] AccountDetailsModel model)
        public async Task<IActionResult> AccountDetailsAsync([FromBody]AccountDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(model);
                //await _context.SaveChangesAsync();
                return Ok("成功收取");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
