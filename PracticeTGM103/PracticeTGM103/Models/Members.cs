using System.ComponentModel.DataAnnotations;

namespace PracticeTGM103.Models
{
    public enum Gender
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

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public MembershipLevels MembershipLevels { get; set; }
        public string BucketList { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}