using System.ComponentModel.DataAnnotations;
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
            None, User, Admin
        }

        /// <summary>
        /// 帳號角色 ID (Primary Key)
        /// </summary>
        [Key]
        public int RoleID { get; set; }

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
        public int MemberId { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
    }
}