<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> [新增]所有資料表
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> [更新加入] 會員 Member/MemberRole 資料內容類別表定義
=======
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
>>>>>>> [更新]Enum/Product/Member表格
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    public class MemberRole
    {
        /// <summary>
        /// Enum 類型，帳號角色種類：
        /// None: 無
        /// User: 一般使用者
        /// Admin: 管理員
        /// </summary>
        public enum RoleType
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> [更新]Enum/Product/Member表格
            [Description("None")]
            None,

            [Description("User")]
            User,

            [Description("Admin")]
            Admin
<<<<<<< HEAD
=======
            None, User, Admin
>>>>>>> [新增]所有資料表
=======
            None, User, Admin
>>>>>>> [更新加入] 會員 Member/MemberRole 資料內容類別表定義
=======
>>>>>>> [更新]Enum/Product/Member表格
        }

        /// <summary>
        /// 帳號角色 ID (Primary Key)
        /// </summary>
        [Key]
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public int RoleId { get; set; }
=======
        public int RoleID { get; set; }
>>>>>>> [新增]所有資料表
=======
        public int RoleID { get; set; }
>>>>>>> [更新加入] 會員 Member/MemberRole 資料內容類別表定義
=======
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [更新] 修正 Member 表中的 Phone 長度, 調整註冊畫面
        public int RoleId { get; set; }
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary

        /// <summary>
        /// 帳號角色類型值
        /// </summary>
        public RoleType Type { get; set; }

        /// <summary>
        /// 帳號角色類型名稱
        /// </summary>
        //public string Name { get; set; }

        /// <summary>
        /// 關聯的會員 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Member")]
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public int MemberId { get; set; }
=======
        public int MemberID { get; set; }
>>>>>>> [新增]所有資料表
=======
        public int MemberID { get; set; }
>>>>>>> [更新加入] 會員 Member/MemberRole 資料內容類別表定義
=======
        public int MemberId { get; set; }
>>>>>>> 新增WishListTable及Api

        /// <summary>
        /// 導覽屬性：只對應到單一會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
    }
}