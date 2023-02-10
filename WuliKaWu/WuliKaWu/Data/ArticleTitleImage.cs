using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    /// <summary>
    /// 資料表 - 部落格文章標題影像
    /// </summary>
    [Table("ArticleTitleImages")]
    public class ArticleTitleImage
    {
        /// <summary>
        /// 標題影像 ID: 自動編號
        /// </summary>
        [Key]
<<<<<<< HEAD
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
        public int Id { get; set; }

        /// <summary>
        /// 關聯之文章 ID
        /// </summary>
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 標題影像路徑
        /// </summary>
<<<<<<< HEAD
        [Required]
<<<<<<< HEAD
<<<<<<< HEAD
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
=======
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
>>>>>>> [更新] 修正 Article 部落格文章相關資料內容類別表, 添加幾筆 seed data 建立相關範例資料
        public string FileName { get; set; }
=======
        public string PicturePath { get; set; }
>>>>>>> [更動] Article 相關資料內容定義表檔案,新增 Migration

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
        public virtual Article Article { get; set; }
    }
<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
}
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
