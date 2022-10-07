using ISSystemDataExporter.Mappers.Parsers;
using Destination = ISSystemDataExporter.Models.Storelocator.Address;
using Source = ISSystemDataExporter.Models.ISSystem.Address;

namespace ISSystemDataExporter.Mappers.Mappers.Impl;

public class AddressMapper : IAddressMapper
{
    private readonly IDictionaryItemMapper dictionaryItemMapper;
    private readonly IXMLContentParser contentParser;

    public AddressMapper(IDictionaryItemMapper dictionaryItemMapper,
        IXMLContentParser contentParser)
    {
        this.dictionaryItemMapper = dictionaryItemMapper;
        this.contentParser = contentParser;
    }

    public Destination Map(Source source)
    {
        return new Destination
        {
            Area = dictionaryItemMapper.Map(source.Region),
            Country = dictionaryItemMapper.Map(source.Country),
            House = source.House,
            Locality = dictionaryItemMapper.Map(source.Town),
            Premise = source.House ?? string.Empty,
            Thoroughfare = contentParser.GetTagInnerText(source.Street),
            ZipCode = source.ZipCode            
        };
    }
}
