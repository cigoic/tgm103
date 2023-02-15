using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Net.Mail;
using System.Text;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/Member/{action}")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IConfiguration _configuration;

        public MemberApiController(ShopContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// 開通帳號
        /// </summary>
        /// <returns></returns>
        [ActionName("Activate")]
        [HttpPost]
        public async Task<LoginMessage> ActivateAsync([FromBody] ActivateModel urlQuery)
        {
            // 解開 Token (email + token)

            //var urlQuery = "u=userxxx@123.com&c=ke%2FVBWYJ4FZXYKJOJN6tC7i";
            var collection = HttpContext.Request.Query;
            //var collection = HttpUtility.ParseQueryString(urlQuery);
            var email = urlQuery.Email; //collection["u"];
            var token = urlQuery.Token; //collection["c"];

            var password = BCrypt.Net.BCrypt.HashPassword(urlQuery.Password, urlQuery.Token);
            bool IsValid = _context.Members.Any(m => m.Password == password);
            //bool IsValid = BCrypt.Net.BCrypt.Verify(urlQuery.Password, token);    // 會失敗
            if (IsValid == false) return new LoginMessage { Status = false, Message = "啟用錯誤，請恰管理員" };

            // IsMemberExisted
            Member? user = await _context.Members
                .SingleOrDefaultAsync(u => u.Email == email);

            if (user == null) return new LoginMessage { Status = false, Message = "啟用錯誤，請恰管理員" };

            user.EmailComfirmed = true;

            await _context.SaveChangesAsync();

            return new LoginMessage { Status = true, Message = "已啟用，Wuli 歡迎您！請先更改會員密碼" };
        }

        /// <summary>
        /// 會員登入頁面的「忘記密碼」功能
        /// </summary>
        [ActionName("ForgetPassword")]
        [HttpPost]
        public async Task<LoginMessage> ForgetPasswordAsync([FromBody] ForgetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return new LoginMessage { Status = false, Message = "重置錯誤，請恰管理員" };
            }
            // 檢查用戶是否存在?
            var thisUser = _context.Members
                        .Any(m => m.Account == model.Account
                        && m.Email == model.Email);
            if (thisUser == false)
            {
                return new LoginMessage { Status = false, Message = "重置錯誤!" };
            }

            // 產生重置密碼 token
            string email = model.Email;
            string token = await GenerateTokenWithEmailAsync(email);

            if (String.IsNullOrEmpty(token))
            {
                return new LoginMessage { Status = false, Message = "無法產生驗證碼，請聯繫管理員!" };
            }

            // 寄送重置密碼連結
            SendPasswordResetEmail(token, email);

            return new LoginMessage { Status = false, Message = "已寄送重置密碼郵件通知!" };
        }

        /// <summary>
        /// 取得 ModelState 錯誤
        /// </summary>
        /// <returns></returns>
        private List<string> GetErrorMessages()
        {
            var errors = new List<string>();
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return errors;
        }

        /// <summary>
        /// 產生 Token (無需會員輸入版本)
        /// </summary>
        /// <param name="HasUser"></param>
        /// <returns></returns>
        private async Task<String> GenerateTokenWithEmailAsync(string email)
        {
            var verificationToken = BCrypt.Net.BCrypt.GenerateSalt();
            try
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.Email == email);
                var token = BCrypt.Net.BCrypt.HashPassword(member.Password, verificationToken);

                if (String.IsNullOrEmpty(verificationToken)
                    || String.IsNullOrEmpty(email)
                    || String.IsNullOrEmpty(token)
                    || member == null)
                    return String.Empty;

                member.VerificationToken = verificationToken;
                member.Password = token;
                member.EmailComfirmed = false;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw; }

            return verificationToken.ToString();
        }

        /// <summary>
        /// 寄送郵件
        /// </summary>
        /// <param name="token"></param>
        private void SendPasswordResetEmail(string token, string email)
        {
            if (email == null) return;

            string targetUrl = Url.Action("Activate", "Member", new { u = email, c = token });
            //產生： "/Member/Activate?u=用戶識別碼&c=Token值"
            //targetUrl = HttpUtility.UrlEncode(targetUrl);
            var link = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{targetUrl}";

            try
            {
                var mail = new MailMessage();
                mail.Subject = "您好！這是一封來自 Wuli 的問候～";
                mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;

                mail.From = new MailAddress("liang.case@gmail.com");
                mail.To.Add(new MailAddress(String.IsNullOrEmpty(email) ? email : "liang.case@gmail.com"));
                mail.Body = @$"<!DOCTYPE html><html lang='zh-tw'><head><meta charset='UTF-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>重置密碼</title></head><body><div><h4>親愛的客戶您好！</h4><h5>這是由系統發出的重置密碼信件，請勿直接回覆！</h5>感謝您對於 Wuli 網站的愛護，您點擊了忘記密碼功能，<br />請點擊下述連結重置密碼：<br /><br /><a href='{link}'>按我重置密碼</a></div></body></html>";

                using (var client = new SmtpClient())
                {
                    var SmtpAccessToken = _configuration.GetValue<string>("SMTPConnection:GmailSMTP");
                    var SmtpAccessUser = _configuration.GetValue<string>("SMTPConnection:Username");
                    var SmtpHostname = _configuration.GetValue<string>("SMTPConnection:Hostname");
                    var SmtpPortNo = Convert.ToInt32(_configuration.GetValue<string>("SMTPConnection:PortNo"));
                    client.Host = SmtpHostname;
                    client.Port = SmtpPortNo;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(SmtpAccessUser, SmtpAccessToken);
                    client.Send(mail);  // 寄信
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        public IResult GetUerInfo()
        {
            var mId = User.Claims.GetMemberId();
            if (mId == 0) return Results.NotFound(new { Status = false, Message = "無法取得資訊！" });

            var member = _context.Members
                .FirstOrDefault(m => m.MemberId == mId);

            return new MemberInfoModel
            {
                Name = member.Name,
                //Gender = m.Gender,
                //MemberShip = m.MemberShip,
                //Email = m.Email,
                //Birthday = m.Birthday,
                //Address = m.Address,
                //PhoneNumber = m.PhoneNumber,
                //MobilePhone = m.MobilePhone,
                //Role = m.Roles.Single().Type,
            } is MemberInfoModel userInfo
                ? Results.Ok(userInfo)
                : Results.NotFound(new { Status = false, Message = "無法取得資訊！" });
        }
    }
}