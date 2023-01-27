namespace WuliKaWu.Models.ApiModel
{
    public class AccountDetailsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string CurrentPwd { get; set; }
        public string NewPwd { get; set; }
        public string ConfirmPwd { get; set; }
    }
}
