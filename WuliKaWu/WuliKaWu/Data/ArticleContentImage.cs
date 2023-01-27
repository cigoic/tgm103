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
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
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
<<<<<<< HEAD
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
=======
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
        public string FileName { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
        // public virtual Article Article { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
