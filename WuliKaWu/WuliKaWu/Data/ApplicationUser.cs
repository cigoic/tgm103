using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        //[ForeignKey("Orders")]
        //public int OrderId { get; set; }

        // TODO:    願望清單是否併入會員資料庫？
        //public WishList WishList
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        [Required]
        [Column(TypeName = "bit")]
        public Boolean Gender { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(16)]
        public string MobilePhone { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public byte Membership { get; set; }

        //public Orders Orders { get; set; }
    }
}