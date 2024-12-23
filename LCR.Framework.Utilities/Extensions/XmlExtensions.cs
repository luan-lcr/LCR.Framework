using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LCR.Framework.Utilities.Extensions;

public static class XmlExtensions
{
    public static string ToXml<T>(this T obj, XmlSerializerNamespaces namespaces = null, XmlWriterSettings settings = null) where T : class
    {
        using var stringWriter = new CustomStringWriter(settings?.Encoding ?? Encoding.UTF8);
        using (var xmlWriter = XmlWriter.Create(stringWriter))
        {
            new XmlSerializer(typeof(T)).Serialize(xmlWriter, obj, namespaces);
        }

        return stringWriter.ToString();
    }

    public static T XmlTo<T>(this string xml) where T : class
    {
        using var reader = new StringReader(xml);
        return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
    }
}

public class CustomStringWriter : StringWriter
{
    private readonly Encoding _encoding;

    public CustomStringWriter(Encoding encoding = null)
    {
        _encoding = encoding ?? Encoding.UTF8;
    }

    public override Encoding Encoding => _encoding;
}
