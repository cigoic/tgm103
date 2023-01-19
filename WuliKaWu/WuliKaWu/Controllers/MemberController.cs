using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Mail;
using System.Security.Claims;

using WuliKaWu.Data;

namespace WuliKaWu.Controllers
{
    public class MemberController : Controller
    {
        [ActionName("Login")]
        public IActionResult LoginRegister()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginRegisterAsync(Member model)
        {
            // TODO 資料庫給的資料
            var dbAccount = "123@123.com";
            var dbPassword = "1314520";

            // 資料庫比對
            // _db.user.where(x => x.account == model.account && x.password == model.password);
            if (model.Account == dbAccount && model.Password == dbPassword)
            {
                // 帳號密碼符合！給 cookie(s): principal > identity > claim
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "NameFromDB"),   // 資料庫裡的姓名
                    new Claim(ClaimTypes.Role, "Admin"),    // 資料庫裡的角色
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim("VIP", "1")   //可以自訂義XXX(例VIP)，但之後不能打錯
                };

                // 直接定義這是"身分證明"
                // 指定 Authentication Type 名稱，以是任何詞彙，但前後端設定必須一致
                // 如果無法，可用 CookieAuthenticationDefaults.AuthenticationScheme
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity); // 到時候要用的憑證

                //HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties()
                //{
                // 何時過期...或填空值
                //});
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }

            TempData["error"] = "帳號密碼不對！";
            return RedirectToAction("LoginRegister");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public void SendMail()
        {
            var mail = new MailMessage();
            mail.Subject = "您好！";
            mail.IsBodyHtml = true;
            mail.Body = "< h1 > Happy New Year~</ h1 >";
            mail.From = new MailAddress("liang.case@gmail.com");
            mail.To.Add(new MailAddress("liang.case@me.com"));

            var client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("liang.case@gmail.com", "MY_PASSWORD");
            client.Send(mail);  // 寄信
        }
    }
}