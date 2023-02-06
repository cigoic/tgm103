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
        public int ArticleId { get; set; }

        /// <summary>
        /// 建立日期: 自動編號
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改日期: 自動編號
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// 作者(會員) ID
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 文章標題 (最長 50 個字元)
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 文章內容
        /// </summary>
        [Required]
        public string Content { get; set; }

        // TODO 可能需要另一張表紀錄多筆評論與此文之關聯
        //public string Comments { get; set; }

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
    }
}