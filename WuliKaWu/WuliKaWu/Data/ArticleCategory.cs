using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    /// <summary>
    /// 資料表 - 部落格文章分類
    /// </summary>
    public class ArticleCategory
    {
        /// <summary>
        /// 資料表 ID: 自動編號
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 關聯之部落格文章 ID
        /// </summary>
        [Required]
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 文章分類
        /// </summary>
        public ArticleType Type { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
        // public virtual Article Article { get; set; }
    }
}
