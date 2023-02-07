namespace WuliKaWu.Models
{
    public class ArticleDetailsModel
    {
<<<<<<< HEAD
<<<<<<< HEAD
        public int ArticleId { get; set; }
=======
>>>>>>> [更新] Blog Index 檢視可顯示單筆部落格文章與圖片
=======
        public int ArticleId { get; set; }
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
        public string MemberName { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD

        public DateTime CreateAt { get; set; }

        public DateTime CreateAt { get; set; }

        public string TitleImageFileName { get; set; }
        public List<string> ContentImageFileNames { get; set; }
        public int PrevArticleId { get; set; }
        public int NextArticleId { get; set; }
        public string PrevArticleTitle { get; set; }
        public string NextArticleTitle { get; set; }
        public DateTime PrevArticleCreateAt { get; set; }
        public DateTime NextArticleCreateAt { get; set; }
<<<<<<< HEAD
=======

        public string TitleImageFileName { get; set; }
        public List<string> ContentImageFileNames { get; set; }
<<<<<<< HEAD
>>>>>>> [更新] Article Details 檢視中部分元素, 改撈取資料庫資料出來顯示
    }
}
=======
    }
}
>>>>>>> [更新] Blog Index 檢視可顯示單筆部落格文章與圖片
=======
        public int PrevArticleId { get; set; }
        public int NextArticleId { get; set; }
=======
>>>>>>> [更新] 修正部落格首頁日期顯示與分頁
    }
}
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
