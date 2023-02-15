namespace WuliKaWu.Models
{
    public class ArticleLastestPostModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TitleImage { get; set; }
    }
}