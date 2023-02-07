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
        public int Id { get; set; }

        /// <summary>
        /// 關聯的文章 ID
        /// </summary>
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 影像路徑
        /// </summary>
        //[MaxLength(1024, ErrorMessage = "含副檔名，長度最多 1024 個字元")]
        public string PicturePath { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
        public virtual Article Article { get; set; }
    }
}