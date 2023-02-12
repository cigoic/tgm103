namespace WuliKaWu.Models
{
    public class ArticleEditModel
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }

        //public string FileName { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CategoryId { get; set; }

        //public string TitleImageFileName { get; set; }
        public List<string>? PicturePath { get; set; }

        //public int PrevArticleId { get; set; }

        //public int NextArticleId { get; set; }
        //public string PrevArticleTitle { get; set; }
        //public string NextArticleTitle { get; set; }
        //public DateTime PrevArticleCreateAt { get; set; }
        //public DateTime NextArticleCreateAt { get; set; }
    }
}