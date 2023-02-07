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
        public virtual ICollection<Article> Articles { get; set; }
    }
}