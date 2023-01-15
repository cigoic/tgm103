<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
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
=======
﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCNetFramework
{
    //[Table("Members")]
    public class Member
    {
        [Required]
        [StringLength(32)]
        public string Name
        {
            get => default;
            set
            {
            }
        }

        public DateTime Birthday
        {
            get => default;
            set
            {
            }
        }

        [ForeignKey("Orders")]
        public int OrderID
        {
            get => default;
            set
            {
            }
        }

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
        public Boolean Gender
        {
            get => default;
            set
            {
            }
        }

        [StringLength(100)]
        public string Address
        {
            get => default;
            set
            {
            }
        }

        [Required]
        [MaxLength(16)]
        public string MobilePhone
        {
            get => default;
            set
            {
            }
        }

        [Required]
        [Column(TypeName = "tinyint")]
        public byte Membership
        {
            get => default;
            set
            {
            }
        }

        public Orders Orders
        {
            get => default;
            set
            {
            }
        }

        public WishList WishList
        {
            get => default;
            set
            {
            }
        }

        public Orders Orders1
        {
            get => default;
            set
            {
            }
        }
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
    }
}