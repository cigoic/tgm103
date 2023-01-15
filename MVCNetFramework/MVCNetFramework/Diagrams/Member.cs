using System;
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
    }
}