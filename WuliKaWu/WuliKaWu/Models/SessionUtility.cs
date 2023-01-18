namespace WuliKaWu.Models
{
    public class Sessionutility<T>
    {
        public static List<T> getCart(HttpContext context, String keyName)
        {
            ISession session = context.Session;
            String? jsonData = session.GetString(keyName);
            List<T>? result = null;
            if (jsonData != null)
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(jsonData);
            }
            return result;
        }
    }
}