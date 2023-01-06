using System.ComponentModel.DataAnnotations;

namespace PracticeTGM103.Models.practice
{
    public class MembersDemo
    {
        [Key]
        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public enum MemberGender
        { Male, Female }

        public DateTime MemberBirth { get; set; }

        public string MemberEmail { get; set; }

        public string MemberAdress { get; set; }

        public string MemberPhone { get; set; }

        public enum MemberVip
        { VIP, SVIP }

        public string? BucketList { get; set; }

        public string MemberAccount { get; set; }

        public string MemberPassword { get; set; }
    }
}