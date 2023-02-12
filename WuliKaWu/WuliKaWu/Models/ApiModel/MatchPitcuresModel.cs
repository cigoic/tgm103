namespace WuliKaWu.Models.ApiModel
{
    public class MatchPicturesModel
    {
        public int ProductId;
        public string ProductName;
        public string PitcurePath;
    }

    public class MatchPartPicturesModel
    {
        public List<MatchPicturesModel> TopsPartsList;
        public List<MatchPicturesModel> BottomPartsList;
        public List<MatchPicturesModel> CoatPartsList;
        public List<MatchPicturesModel> DressPartsList;
    }
}