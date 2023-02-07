using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> [更新] 忘記密碼功能與改用 Vue.js 渲染
using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Net.Mail;
using System.Text;
<<<<<<< HEAD
=======
>>>>>>> [更新] 調整會員登入使用 ClaimsType.Sid, RoleType 使用 Description 描述, 以及登入頁面
=======
>>>>>>> [更新] 忘記密碼功能與改用 Vue.js 渲染

using WuliKaWu.Data;
using WuliKaWu.Models;

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
<<<<<<< HEAD
<<<<<<< HEAD

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

<<<<<<< HEAD
=======
>>>>>>> [更新] 調整會員登入使用 ClaimsType.Sid, RoleType 使用 Description 描述, 以及登入頁面
=======


>>>>>>> [更新] 忘記密碼功能與改用 Vue.js 渲染
=======
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
>>>>>>> [更新] 會員重置密碼、驗證信寄送、新增啟用會員帳號功能, 修正 _Layout 中 Sweetalert2 JS 引用連結
    }
}