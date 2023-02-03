using System.Security.Claims;

namespace WuliKaWu.Extensions
{
    public static class ClaimExtension
    {
        public static int GetMemberId(this IEnumerable<Claim> claims)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return int.TryParse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out var memberId) ? memberId : throw new ArgumentNullException("找不到ID");

        }

        public static bool GetRememberMeStatus(this IEnumerable<Claim> claims)
        {
            return bool.TryParse(claims.FirstOrDefault(x => x.Type == "RememberMe")?.Value, out var memberId) ? memberId : false;
=======
            return int.TryParse(claims.FirstOrDefault(x => x.Type == "Id")?.Value, out var memberId) ? memberId : -1;
>>>>>>> [新增]ClaimExtension Class的GetMemberId
=======
            return int.TryParse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out var memberId) ? memberId : -1;
>>>>>>> [更新] 調整會員登入使用 ClaimsType.Sid, RoleType 使用 Description 描述, 以及登入頁面
        }

        public static bool GetRememberMeStatus(this IEnumerable<Claim> claims)
        {
            return bool.TryParse(claims.FirstOrDefault(x => x.Type == "RememberMe")?.Value, out var memberId) ? memberId : false;
        }
    }
}