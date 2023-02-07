using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    /// <summary>
    /// 資料表 - 部落格文章分類
    /// </summary>
    [Table("ArticleCategories")]
    public class ArticleCategory
    {
        /// <summary>
        /// 資料表 ID: 自動編號
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
        /// 部落格文章分類
        /// Uncategorized: 未分類
        /// BlogGridView: 部落格 GridView
        /// LatestBlog: 最新文章
        /// OurBlog: 關於我們的文章
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public virtual Article Article { get; set; }
=======
        public virtual ICollection<Article> Articles { get; set; }
>>>>>>> [更動] Article 相關資料內容定義表檔案,新增 Migration
    }
<<<<<<< HEAD
}
=======
        // public virtual Article Article { get; set; }
=======
        public virtual Article Article { get; set; }
>>>>>>> [更新] 修正 Article 部落格文章相關資料內容類別表, 添加幾筆 seed data 建立相關範例資料
    }
}
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
}
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
