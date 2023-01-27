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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 作者(會員) ID
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 第一張作者圖像檔案名稱(不含路徑)
        /// </summary>
        public string? FirstImageFileName { get; set; }

        /// <summary>
        /// 第二張作者圖像檔案名稱(不含路徑)
        /// </summary>
        public string? SecondImageFileName { get; set; }
    }
}
