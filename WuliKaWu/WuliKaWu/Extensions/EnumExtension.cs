using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace WuliKaWu.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescriptionText<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
             typeof(DescriptionAttribute), false);
            if (attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
