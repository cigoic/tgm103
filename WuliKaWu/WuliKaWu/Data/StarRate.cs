using static WuliKaWu.Data.Enums.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WuliKaWu.Data
{
    [Table("StarRate")]
    public class StarRate
    {
        /// <summary>
        /// 星等ID(Primary Key)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 關聯的商品 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

<<<<<<< HEAD
        [ForeignKey("Member")]
        public int MemberId { get; set; }

        /// <summary>
        /// 商品的星等類型值
        /// </summary>
        public StarRateEnum Type { get; set; }
=======
        /// <summary>
        /// 商品的星等類型值
        /// </summary>
        public StarRate Type { get; set; }
>>>>>>> 暫時修改

        /// <summary>
        /// 導覽屬性：只對應到單一商品，不用 ICollection
        /// </summary>
        public virtual Product Product { get; set; }
<<<<<<< HEAD
        public virtual Member Member { get; set; }
=======
>>>>>>> 暫時修改
    }
}
