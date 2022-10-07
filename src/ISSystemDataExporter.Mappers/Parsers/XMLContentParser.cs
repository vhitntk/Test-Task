using System.Web;
using System.Xml.Linq;

namespace ISSystemDataExporter.Mappers.Parsers;

public class XMLContentParser : IXMLContentParser
{
    //TODO: make it configurable ?
    const string ruLangId = "1049";
    const string elementName = "item";

    public string? GetTagInnerText(string? xmlFragment)
    {
        if (string.IsNullOrWhiteSpace(xmlFragment))
        {
            return null;
        }
        var decoded = HttpUtility.HtmlDecode(xmlFragment);
        var doc = XDocument.Parse(decoded);
        var node = doc.Descendants().First(x => x.Name.LocalName == elementName && IsRuLang(x));
        return node.Value;
    }

    private static bool IsRuLang(XElement element)
    {
        return element.HasAttributes && 
            element.Attributes().Single(x => x.Name == "LanguageID" && x.Value == ruLangId) != null;
    }
}