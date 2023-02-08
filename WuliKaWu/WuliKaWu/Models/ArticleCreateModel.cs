namespace WuliKaWu.Models
{
    public class ArticleCreateModel
    {
        //public int MemberId { get; set; }
        //public DateTime CreatedDate { get; set; }

        //public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}