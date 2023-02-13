namespace MVCNetFramework.Controllers
{
    /// <summary>
    /// 資料表 - 作者(會員)大頭照
    /// </summary>
    [Table("AuthorImages")]
    public class AuthorImage
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 關聯的作者(會員)
        /// </summary>
        [ForeignKey("Member")]
        public int MemberId { get; set; }

        /// <summary>
        /// 作者圖像檔案路徑
        /// </summary>
        public string PicturePatch { get; set; }

        /// <summary>
        /// 導覽屬性：作者(會員)
        /// </summary>
        public virtual Member Memeber { get; set; }
    }
}