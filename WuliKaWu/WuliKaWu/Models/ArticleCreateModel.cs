namespace WuliKaWu.Models
{
    public class ArticleCreateModel
    {
        public string Title { get; set; }

        public string Content { get; set; }
        public int CategoryId { get; set; }
        public IFormCollection Images { get; set; }
    }
}