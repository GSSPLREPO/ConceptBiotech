using System;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Serialization;

namespace ConceptBiotech.Business
{
    public static class Extended
    {
        public static object GetPropValue(object src, string propName)
        {
            if (src != null)
            {
                return src.GetType().GetProperty(propName).GetValue(src, null);
            }
            else
            {
                return null;
            }
        }

        public static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

        public static string SerializeObject<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
