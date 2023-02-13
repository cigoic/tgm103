namespace MVCNetFramework.Controllers
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
        public int Id { get; set; }

        /// <summary>
        /// 關聯之文章 ID
        /// </summary>
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 標題影像路徑
        /// </summary>
        public string PicturePath { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
        public virtual Article Article { get; set; }
    }
}