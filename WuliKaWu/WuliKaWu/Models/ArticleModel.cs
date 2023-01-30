namespace WuliKaWu.Models
{
    public class ArticleModel
    {
        public int ArticleId { get; set; }
        public string MemberName { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string TitleImageFileName { get; set; }
        public List<string> ContentImageFileNames { get; set; }
        public int PrevArticleId { get; set; }
        public int NextArticleId { get; set; }
    }
}