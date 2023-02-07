using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    /// <summary>
    /// 資料表 - 部落格文章
    /// </summary>
    [Table("Articles")]
    public class Article
    {
        /// <summary>
        /// 文章 ID : 自動編號
        /// </summary>
        [Key]
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
        public int ArticleId { get; set; }
=======
        public int Id { get; set; }

        /// <summary>
        /// 作者(會員) ID
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }
>>>>>>> [更動] Article 相關資料內容定義表檔案,新增 Migration

        /// <summary>
        /// 建立日期: 自動編號
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改日期: 自動編號
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// 文章標題 (最長 128 個字元)
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        /// <summary>
        /// 文章內容
        /// </summary>
        [Required]
        public string Content { get; set; }

        // TODO 可能需要另一張表紀錄多筆評論與此文之關聯
        //public string? Comments { get; set; }

        /// <summary>
        /// 導覽屬性: 文章關聯之標題影像表
        /// </summary>
        public virtual ICollection<ArticleTitleImage> ArticleTitleImages { get; set; }

        /// <summary>
        /// 導覽屬性: 文章關聯之分類表
        /// </summary>
        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }

        /// <summary>
        /// 導覽屬性: 文章關聯之影像表
        /// </summary>
        public virtual ICollection<ArticleContentImage> ArticleContentImages { get; set; }

        /// <summary>
        /// 導覽屬性：對應到多個商品標籤，用 ICollection
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
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
