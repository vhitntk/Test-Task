using ISSystemDataExporter.Mappers.Parsers;
using Destination = ISSystemDataExporter.Models.Storelocator.DictionaryItem;
using Source = ISSystemDataExporter.Models.ISSystem.DictionaryItem;

namespace ISSystemDataExporter.Mappers.Mappers.Impl;

public sealed class DictionaryItemMapper : IDictionaryItemMapper
{
    private readonly IXMLContentParser contentParser;

    public DictionaryItemMapper(IXMLContentParser contentParser)
    {
        this.contentParser = contentParser;
    }

    public Destination Map(Source source)
    {
        return new Destination
        {
            Id = source.ItemID,
            Text = contentParser.GetTagInnerText(source.ItemCaption)
        };
    }
}