﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    /// <summary>
    /// 資料表 - 作者(會員)大頭照
    /// </summary>
    [Table("AuthorImages")]
    public class AuthorImage
    {
        [Key]
<<<<<<< HEAD
<<<<<<< HEAD
        public int Id { get; set; }

=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
        public int Id { get; set; }

>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
        /// <summary>
        /// 關聯的作者(會員)
        /// </summary>
        [ForeignKey("Member")]
        public int MemberId { get; set; }

        /// <summary>
        /// 作者圖像檔案路徑
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
        public string? FirstImageFileName { get; set; }
=======
        public string PicturePatch { get; set; }
>>>>>>> [更動] Article 相關資料內容定義表檔案,新增 Migration

        /// <summary>
        /// 導覽屬性：作者(會員)
        /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
        public string? SecondImageFileName { get; set; }
    }
}
=======
=======
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
>>>>>>> [更新] 修正 Article 部落格文章相關資料內容類別表, 添加幾筆 seed data 建立相關範例資料
        public string? SecondImageFileName { get; set; }
=======
        public virtual Member Memeber { get; set; }
>>>>>>> [更動] Article 相關資料內容定義表檔案,新增 Migration
    }
<<<<<<< HEAD
}
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
=======
}
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
