﻿using System.ComponentModel.DataAnnotations;
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
        public int Id { get; set; }

        /// <summary>
        /// 關聯之文章 ID
        /// </summary>
        [Required]
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 標題影像檔名(不含路徑)
        /// </summary>
        [Required]
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
        public string FileName { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
        // public virtual Article Article { get; set; }
    }
}