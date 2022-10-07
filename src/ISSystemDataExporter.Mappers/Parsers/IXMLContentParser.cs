namespace ISSystemDataExporter.Mappers.Parsers;

public interface IXMLContentParser
{
    string? GetTagInnerText(string? xmlFragment);
}
