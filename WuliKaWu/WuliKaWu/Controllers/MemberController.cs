using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models;
using WuliKaWu.Models.ApiModel;

using static WuliKaWu.Data.MemberRole;

namespace WuliKaWu.Controllers
{
    /// <summary>
    /// 會員登入系統
    /// 提供「登入」、「註冊」、「忘記密碼」功能
    /// </summary>
    public class MemberController : Controller
    {
        private readonly ShopContext _context;
        private readonly IConfiguration _configuration;

        public MemberController(ShopContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// 會員登入、註冊首頁
        /// </summary>
        /// <returns></returns>
        [ActionName("Login")]
        public IActionResult LoginRegister()
        {
            return View();
        }

        /// <summary>
        /// 會員登入
        /// </summary>
        /// <param name="model">登入所需資訊</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginRegisterAsync(MemberLoginModel model)
        {
            // 資料庫比對
            var member = _context.Members
                            .SingleOrDefault(x => x.Account == model.Account && x.EmailComfirmed == true);

            if (member == null || !BCrypt.Net.BCrypt.Verify(model.Password, member.Password))
            {
                return RedirectToAction("Login", new LoginMessage { Status = false, Message = "錯誤，請再試一次" });
                //return new LoginMessage { Status = false, Message = "錯誤，請再試一次" };
            }

            // 帳號密碼符合！給 cookie(s): principal > identity > claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, member.Name),   // 資料庫裡的姓名
                // https://learn.microsoft.com/zh-tw/windows-server/identity/ad-fs/technical-reference/the-role-of-claims
                new Claim(ClaimTypes.Role, RoleType.User.GetDescriptionText()),    // 資料庫裡的角色
                //new Claim(ClaimTypes.Role, "User"),
                //new Claim("VIP", "1")   //可以自訂義XXX(例VIP)，但之後不能打錯
                //new Claim("Id", member.MemberId.ToString()),
                new Claim("RememberMe", model.RememberMe.ToString()),
                new Claim(ClaimTypes.Sid, member.MemberId.ToString()),
                //new Claim(ClaimTypes.GivenName, member.FirstName),
                //new Claim(ClaimTypes.Surname, member.LastName),
                //new Claim(ClaimTypes.Email, member.Email),
                //new Claim(ClaimTypes.Gender, member.Gender),
                //new Claim(ClaimTypes.DateOfBirth, member.Birthday),
                //new Claim(ClaimTypes.HomePhone, member.PhoneNumber),
                //new Claim(ClaimTypes.MobilePhone, member.MobilePhone),
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
            // return new LoginMessage { Status = true, Message = $"歡迎回來！{User.Identity?.Name}" };
        }

        /// <summary>
        /// 會員註冊
        /// </summary>
        /// <param name="model">註冊所需資訊</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                if (model == null
                    || _context.Members.Any(u => u.Account == model.Account)
                    || _context.Members.Any(u => u.Email == model.Email)
                    || !ModelState.IsValid)
                    return BadRequest(new { success = false, Message = "錯誤，請再試一次" });

                var verificationToken = BCrypt.Net.BCrypt.GenerateSalt();

                _context.Members.Add(new Member
                {
                    Account = model.Account,
                    // Hash the password
                    // Install-Package BCrypt.Net-Next
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password, verificationToken),
                    VerificationToken = verificationToken,
                    Name = model.Name,
                    Gender = model.Gender,
                    Birthday = model.Birthday,
                    Email = model.Email,
                    EmailComfirmed = false,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    MobilePhone = model.MobilePhone,
                    MemberShip = MemberShipType.NormalUser,
                    //LockOutEnabled = false,
                    //AccessFailedCount = 0,
                });

                await _context.SaveChangesAsync();

                // 發送會員註冊啟用信件
                SendConfirmationEmail(model.Email, "啟用會員帳號", verificationToken);
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction("Login");
        }

        /// <summary>
        /// 登出會員帳號，同時清除 Session
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            if (HttpContext.Session != null)
                HttpContext.Session.Clear();    // 清除 Session

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Account Details 頁面入口
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        [Authorize]
        public IActionResult MyAccount()
        {
            return View();
        }

        // TODO 收取提交表單資料,並寫入會員資料庫
        /// <summary>
        /// Account Details 頁面「更改會員資訊」
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyAccount(AccountDetailsModel model)
        {
            if (User.Identity?.IsAuthenticated == false || ModelState.IsValid == false)
                return BadRequest(new { Status = false, Message = "錯誤，請恰管理員" });

            // TODO 管理角色
            //var model = new MemberModel();
            //model.MemberId = User.Claims.GetMemberId();
            //model.Name = User.Identity.Name;
            //model.RememberMe = User.Claims.GetRememberMeStatus();
            //return View(model);

            var member = _context.Members
                .FirstOrDefault(m => m.MemberId == User.Claims.GetMemberId());
            var NewVerificationToken = BCrypt.Net.BCrypt.GenerateSalt();

            if (member == null || member.EmailComfirmed == true || String.IsNullOrEmpty(NewVerificationToken))
                return BadRequest(new { Status = false, Message = "錯誤，請恰管理員" });

            member.Name = $"{model.LastName}+{model.FirstName}";
            member.Email = model.Email;
            member.VerificationToken = NewVerificationToken;
            member.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPwd, NewVerificationToken);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyAccount));
        }

        /// <summary>
        /// 會員登入頁面的「忘記密碼」功能
        /// </summary>
        public IActionResult ForgetPassword()
        {
            return View();
        }

        /// <summary>
        /// 開通帳號
        /// </summary>
        /// <returns></returns>
        public IActionResult Activate()
        {
            IQueryCollection collection = HttpContext.Request.Query;
            if (collection == null) RedirectToAction("Login");

            return View(new ActivateModel { Email = collection["u"], Token = collection["c"] });
        }

        // TODO 重複功能，將移至 ApiController 中
        private void SendConfirmationEmail(string email, string subject, string token)
        {
            if (email == null) return;

            string targetUrl = Url.Action("Activate", "Member", new { u = email, c = token });
            var link = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{targetUrl}";

            using (var smtpClient = new SmtpClient())
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@example.com"),
                    To = { email },
                    Subject = subject,
                    Body = $"<h3>感謝您註冊成為 Wuli 會員！</h3><br/>請點擊下述連結，請至您的信箱收取確認信！<br/><hr/><a href='{link}'>{subject}</a>",
                    IsBodyHtml = true,
                    SubjectEncoding = Encoding.UTF8
                };

                var SmtpAccessToken = _configuration.GetValue<string>("SMTPConnection:GmailSMTP");
                var SmtpAccessUser = _configuration.GetValue<string>("SMTPConnection:Username");
                var SmtpHostname = _configuration.GetValue<string>("SMTPConnection:Hostname");
                var SmtpPortNo = Convert.ToInt32(_configuration.GetValue<string>("SMTPConnection:PortNo"));
                smtpClient.Host = SmtpHostname;
                smtpClient.Port = SmtpPortNo;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(SmtpAccessUser, SmtpAccessToken);
                smtpClient.Send(mailMessage);
            }
        }
    }
}