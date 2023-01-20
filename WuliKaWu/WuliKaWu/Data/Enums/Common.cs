<<<<<<< HEAD
﻿using System.ComponentModel;

namespace WuliKaWu.Data.Enums
{
    public class Common
    {
        /// <summary>
        /// Enum 類型，付款方式：
        /// Cash: 現金_0
        /// CreditCard: 信用卡_1
        /// MobilePay: 線上支付_2
        /// </summary>
        public enum GetPayType
        {
            [Description("Cash")]
            Cash,

            [Description("CreditCard")]
            CreditCard,

            [Description("MoblilePay")]
            MoblilePay
        }

        /// <summary>
        /// Enum 類型，商品顏色:
        /// Black: 黑色_0
        /// White: 白色_1
        /// Brown: 咖啡色_2
        /// Red: 紅色_3
        /// Orange: 橘色_4
        /// </summary>
        public enum Color
        {
            [Description("Black")]
            Black = 0,

            [Description("White")]
            White = 1,

            [Description("Brown")]
            Brown = 2,

            [Description("Red")]
            Red = 3,

            [Description("Orange")]
            Orange = 4
        }

        /// <summary>
        /// Enum 類型，商品尺寸:
        /// XS: 0
        /// S: 1
        /// M: 2
        /// L: 3
        /// XL: 4
        /// </summary>
        public enum Size
        {
            [Description("XS")]
            XS,

            [Description("S")]
            S,

            [Description("M")]
            M,

            [Description("L")]
            L,

            [Description("XL")]
            XL
        }

        /// <summary>
        /// Enum 類型，商品星等:
        /// NoStar: 0
        /// OneStar: 1
        /// TwoStar: 2
        /// ThreeStar: 3
        /// FourStar: 4
        /// FiveStar: 5
        /// </summary>
        public enum StarRateEnum
        {
            [Description("NoStar")]
            NoStar = 0,

            [Description("OneStar")]
            OneStar = 1,

            [Description("TwoStar")]
            TwoStar = 2,

            [Description("ThreeStar")]
            ThreeStar = 3,

            [Description("FourStar")]
            FourStar = 4,

            [Description("FiveStar")]
            FiveStar = 5
        }

        /// <summary>
        /// Enum 類型，商品標籤:
        /// Hot: 熱銷_0
        /// New: 新品_1
        /// Spring: 春裝_2
        /// Winter: 冬裝_3
        /// </summary>
        public enum Tag
        {
            [Description("Hot")]
            Hot,

            [Description("New")]
            New,

            [Description("Spring")]
            Spring,

            [Description("Winter")]
            Winter
        }

        /// <summary>
        /// Enume 類型，部落格文章分類
        /// Uncategorized: 未分類
        /// BlogGridView: 部落格 GridView
        /// LatestBlog: 最新文章
        /// OurBlog: 關於我們的文章
        /// </summary>
        public enum ArticleType
        {
            [Description("Uncategorized")]
            Uncategorized,

            [Description("BlogGridView")]
            BlogGridView,

            [Description("LatestBlog")]
            LatestBlog,

            [Description("OurBlog")]
            OurBlog
=======
﻿namespace WuliKaWu.Data.Enums
{
    public class Common
    {
        /// <summary>
        /// Enum 類型，付款方式：
        /// Cash: 現金_0
        /// CreditCard: 信用卡_1
        /// MobilePay: 線上支付_2
        /// </summary>
        public enum GetPayType
        { Cash, CreditCard, MoblilePay }

        /// <summary>
        /// Enum 類型，商品顏色:
        /// Black: 黑色_0
        /// White: 白色_1
        /// Brown: 咖啡色_2
        /// Red: 紅色_3
        /// Orange: 橘色_4
        /// </summary>
        public enum Color
        {
            Black = 0, White = 1, Brown = 2, Red = 3, Orange = 4
        }

        /// <summary>
        /// Enum 類型，商品尺寸:
        /// XS: 0
        /// S: 1
        /// M: 2
        /// L: 3
        /// XL: 4
        /// </summary>
        public enum Size
        {
            XS, S, M, L, XL
        }

        /// <summary>
        /// Enum 類型，商品星等:
        /// NoStar: 0
        /// OneStar: 1
        /// TwoStar: 2
        /// ThreeStar: 3
        /// FourStar: 4
        /// FiveStar: 5
        /// </summary>
        public enum StarRate
        {
            NoStar = 0, OneStar = 1, TwoStar = 2, ThreeStar = 3, FourStar = 4, FiveStar = 5
        }

        /// <summary>
        /// Enum 類型，商品分類:
        /// Tops: 上衣_0
        /// Buttoms: 下身_1
        /// Outer: 外套_2
        /// Dress: 洋裝_3
        /// </summary>
        public enum Category
        {
            Tops, Buttoms, Outer, Dress
        }

        /// <summary>
        /// Enum 類型，商品標籤:
        /// Hot: 熱銷_0
        /// New: 新品_1
        /// Spring: 春裝_2
        /// Winter: 冬裝_3
        /// </summary>
        public enum Tag
        {
            Hot, New, Spring, Winter
>>>>>>> [更新] 資料庫資料表
        }
    }
}