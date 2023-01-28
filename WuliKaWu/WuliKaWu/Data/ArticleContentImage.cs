using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    /// <summary>
    /// 部落格文章影像關聯表
    /// </summary>
    public class ArticleContentImage
    {
        /// <summary>
        /// 影像 ID, 自動編號
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 關聯的文章 ID
        /// </summary>
        [Required]
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 影像檔名(不含路徑)
        /// </summary>
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
        public string FileName { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
        // public virtual Article Article { get; set; }
    }
}
