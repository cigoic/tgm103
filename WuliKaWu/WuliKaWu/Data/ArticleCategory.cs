﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    /// <summary>
    /// 資料表 - 部落格文章分類
    /// </summary>
    public class ArticleCategory
    {
        /// <summary>
        /// 資料表 ID: 自動編號
        /// </summary>
        [Key]
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
        public int Id { get; set; }

        /// <summary>
        /// 關聯之部落格文章 ID
        /// </summary>
        [Required]
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }

        /// <summary>
        /// 文章分類
        /// </summary>
        public ArticleType Type { get; set; }

        /// <summary>
        /// 導覽屬性: 關聯的文章
        /// </summary>
<<<<<<< HEAD
        public virtual Article Article { get; set; }
    }
}
=======
        // public virtual Article Article { get; set; }
    }
}
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
