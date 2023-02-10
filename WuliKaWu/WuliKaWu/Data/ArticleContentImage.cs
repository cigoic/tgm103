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
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
        public int Id { get; set; }

        /// <summary>
        /// 關聯的文章 ID
        /// </summary>
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 影像路徑
        /// </summary>
<<<<<<< HEAD
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
        //[MaxLength(1024, ErrorMessage = "含副檔名，長度最多 1024 個字元")]
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
