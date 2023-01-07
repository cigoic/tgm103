using System.ComponentModel.DataAnnotations;

namespace PracticeTGM103.Models.Products
{
    public enum MemberGender
    {
        Male = 1, Female = 2
    }

    public enum MembershipLevels
    {
        VIP = 1, Regular = 2, Trial = 3
    }

    public class Members
    {
        [Key]
        public int MembersId { get; set; }

        public string MemberName { get; set; }
        public MemberGender? MemberGender { get; set; }
        public int MemberAge { get; set; }
        public DateTime Birth { get; set; }
        public string MemberEmail { get; set; }
        public string MemberAddress { get; set; }
        public string MemberPhone { get; set; }
        public MembershipLevels? MembershipLevels { get; set; }
        public string BucketList { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}