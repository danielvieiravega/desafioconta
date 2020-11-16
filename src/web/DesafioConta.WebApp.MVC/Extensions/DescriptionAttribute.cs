using System.ComponentModel;
using System.Reflection;

namespace DesafioConta.WebApp.MVC.Extensions
{
    public static class DescriptionAttributeExtensions
    {
        public static string DescriptionAttribute<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) 
                return attributes[0].Description;
            else 
                return source.ToString();
        }
    }
}