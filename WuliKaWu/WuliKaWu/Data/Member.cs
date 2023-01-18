using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Members")]
    public class Member //: IdentityUser<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(16)]
        public string Account { get; set; }

        public string Password { get; set; }

        [MaxLength(24)]
        public string Name { get; set; }

        //public virtual ICollection<MemberLike> MemberLikes { get; set; }  // Add UserId (FK) in MemberLikes
    }
}