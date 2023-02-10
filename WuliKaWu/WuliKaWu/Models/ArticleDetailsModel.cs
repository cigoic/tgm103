namespace WuliKaWu.Models
{
    public class ArticleDetailsModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; }

        //public string FileName { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        //public string TitleImageFileName { get; set; }
        //public List<string> ContentImageFileNames { get; set; }
        public int PrevArticleId { get; set; }

        public int NextArticleId { get; set; }
        public string PrevArticleTitle { get; set; }
        public string NextArticleTitle { get; set; }
        public DateTime PrevArticleCreateAt { get; set; }
        public DateTime NextArticleCreateAt { get; set; }
    }
}