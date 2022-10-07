using ISSystemDataExporter.Mappers.Parsers;
using Destination = ISSystemDataExporter.Models.Storelocator.Companydetail;
using Source = ISSystemDataExporter.Models.ISSystem.AdditionalParameter;

namespace ISSystemDataExporter.Mappers.Mappers.Impl;

public class AdditionalParameterMapper : IAdditionalParameterMapper
{
    private readonly IXMLContentParser contentParser;

    public AdditionalParameterMapper(IXMLContentParser contentParser)
    {
        this.contentParser = contentParser;
    }

    public Destination Map(Source source)
    {
        return new Destination
        {
            Code = source.Code,
            Name = contentParser.GetTagInnerText(source.Name),
            Value = source.Value
        };
    }
}
