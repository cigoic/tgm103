using WuliKaWu.Data;

using static WuliKaWu.Data.MemberRole;

namespace WuliKaWu.Models
{
    public class RegisterModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public MemberShipType MemberShip { get; set; }
        public int MemberId { get; set; }
        public RoleType RoleType { get; set; }
    }
}