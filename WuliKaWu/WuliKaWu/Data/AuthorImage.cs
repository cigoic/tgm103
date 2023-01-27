using System.ComponentModel.DataAnnotations;
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
        public int Id { get; set; }

=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
        /// <summary>
        /// 作者(會員) ID
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 第一張作者圖像檔案名稱(不含路徑)
        /// </summary>
<<<<<<< HEAD
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
=======
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
        public string? FirstImageFileName { get; set; }

        /// <summary>
        /// 第二張作者圖像檔案名稱(不含路徑)
        /// </summary>
<<<<<<< HEAD
        [MaxLength(256, ErrorMessage = "含副檔名，長度最多 256 個字元")]
        public string? SecondImageFileName { get; set; }
    }
}
=======
        public string? SecondImageFileName { get; set; }
    }
}
>>>>>>> [新增] Article, ArticleCategory,...等,部落格文章相關資料類別表和 MyAccount 檢視頁面.
