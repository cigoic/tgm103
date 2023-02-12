namespace WuliKaWu.Models
{
    public class ArticleUpdateModel
    {
        public int ArticleId { get; set; }
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}