namespace MVCNetFramework.Controllers
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
        public int Id { get; set; }

        /// <summary>
        /// 作者(會員) ID
        /// </summary>
        [ForeignKey("Member")]
        public int MemberId { get; set; }

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

        /// <summary>
        /// 文章簡述（最長 128 個字元）
        /// </summary>
        [MaxLength(128)]
        public string Description { get; set; }

        /// <summary>
        /// 分類，不可為NULL
        /// </summary>
        [ForeignKey("ArticleCategory")]
        public int CategoryId { get; set; }

        // TODO 可能需要另一張表紀錄多筆評論與此文之關聯
        //public string? Comments { get; set; }

        /// <summary>
        /// 導覽屬性: 文章關聯之標題影像表
        /// </summary>
        public virtual ArticleTitleImage ArticleTitleImage { get; set; }

        /// <summary>
        /// 導覽屬性: 文章關聯之分類表
        /// </summary>
        public virtual ArticleCategory ArticleCategory { get; set; }

        /// <summary>
        /// 導覽屬性: 文章關聯之影像表
        /// </summary>
        public virtual ICollection<ArticleContentImage> ArticleContentImages { get; set; }

        /// <summary>
        /// 導覽屬性：對應到多個商品標籤，用 ICollection
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
    }
}