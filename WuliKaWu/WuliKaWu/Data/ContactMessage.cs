using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("ContactMessages")]
    public class ContactMessage
    {
        /// <summary>
        /// 聯絡訊息 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        public int MessageId { get; set; }

        /// <summary>
        /// 關聯的會員 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Member")]
        public int MemberId { get; set; }

        /// <summary>
        /// 會員姓名，最大長度 24
        /// </summary>
        [MaxLength(24)]
        public string Name { get; set; }

        /// <summary>
        /// 會員電子信箱，最大長度 256
        /// </summary>

        [MaxLength(256)]
        public string Email { get; set; }

        /// <summary>
        /// 標題，最大長度 20
        /// </summary>
        [MaxLength(60)]
        [Column(TypeName = "nvarchar")]
        public String Subject { get; set; }

        /// <summary>
        /// 手機號碼，最大長度 16
        /// </summary>
        //TODO MaxLength、StringLenth差別在哪?
        [MaxLength(16)]
        [Column(TypeName = "nvarchar")]
        public String Phone { get; set; }

        /// <summary>
        /// 訊息，最大長度 256
        /// </summary>
        [MaxLength(256)]
        [Column(TypeName = "nvarchar")]
        public String Message { get; set; }

        /// <summary>
        /// 導覽屬性:只對應到單一會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
    }
}