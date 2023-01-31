using System.Security.Claims;

namespace WuliKaWu.Extensions
{
    public static class ClaimExtension
    {
        public static int GetMemberId(this IEnumerable<Claim> claims)
        {
            return int.TryParse(claims.FirstOrDefault(x => x.Type == "Id")?.Value, out var memberId) ? memberId : -1;
        }
    }
}