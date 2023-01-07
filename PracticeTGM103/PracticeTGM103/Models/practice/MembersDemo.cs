using System.ComponentModel.DataAnnotations;

namespace PracticeTGM103.Models.practice
{
    public enum MemberGender
    { Male, Female }

    public class MembersDemo
    {
        [Key]
        public int MemberId { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public enum MemberVip
        { VIP, SVIP }

        public string? BucketList { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }
    }
}