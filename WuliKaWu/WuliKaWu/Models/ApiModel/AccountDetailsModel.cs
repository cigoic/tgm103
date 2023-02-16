namespace WuliKaWu.Models.ApiModel
{
    public class AccountDetailsModel
    {
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string MemberShip { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public string CurrentPwd { get; set; }
        public string NewPwd { get; set; }
        public string ConfirmPwd { get; set; }
    }
}