using ISSystemDataExporter.Mappers.Parsers;
using Destination = ISSystemDataExporter.Models.Storelocator.Company;
using Source = ISSystemDataExporter.Models.ISSystem.CompanyPropertyContainer;

namespace ISSystemDataExporter.Mappers.Mappers.Impl;

public sealed class CompanyMapper : ICompanyMapper
{
    //Исходный XML содержит больше элементов в коллекции, чем результирующий JSON. Здесь коды только тех элементов, которые есть в JSON.
    private string[] companyDetailCodes = 
    {
        "company_inn",
        "company_kpp",
        "test_text_wUnit",
        "company_sap",
        "misc.other"
    };

    private readonly IDictionaryItemMapper dictionaryItemMapper;
    private readonly IAddressMapper addressMapper;
    private readonly IAdditionalParameterMapper additionalParameterMapper;
    private readonly IXMLContentParser contentParser;

    public CompanyMapper(IDictionaryItemMapper dictionaryItemMapper,
        IAddressMapper addressMapper,
        IAdditionalParameterMapper additionalParameterMapper,
        IXMLContentParser contentParser)
    {
        this.dictionaryItemMapper = dictionaryItemMapper;
        this.addressMapper = addressMapper;
        this.additionalParameterMapper = additionalParameterMapper;
        this.contentParser = contentParser;
    }

    public Destination Map(Source source)
    {
        var company = source.Company;
        return new Destination
        {
            Activities = company.Details.Activities.Select(x => dictionaryItemMapper.Map(x)).ToArray(),
            ActualAddress = addressMapper.Map(company.Details.ActualAddress),
            BusinessRegions = company.Details.BusinessRegion.Select(x => dictionaryItemMapper.Map(x)).ToArray(),
            CompanyDetails = company.Details.FiscalAdditionalParameterSet.Parameters.AdditionalParameter
                .Where(x => IncludeCompanyDetail(x.Code))
                .Select(x => additionalParameterMapper.Map(x)).ToArray(),
            Contacts = Array.Empty<object>(),
            ContactUid = source.Property.FirstOrDefault()?.Owner.UID,
            EntityType = dictionaryItemMapper.Map(company.Details.EntityType),
            FullName = ExtractFullName(contentParser.GetTagInnerText(source.Property.FirstOrDefault()?.Owner.Caption)),
            LegalAddress = addressMapper.Map(company.Details.LegalAddress),
            LegalForm = dictionaryItemMapper.Map(company.Details.LegalForm),
            LegalName = contentParser.GetTagInnerText(company.Details.LegalName),
            Name = contentParser.GetTagInnerText(company.Details.Name),
        };
    }

    private string? ExtractFullName(string? source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return null;
        }
        return source.Split(",").FirstOrDefault() ?? null;
    }

    private bool IncludeCompanyDetail(string detailCode)
    {
        return companyDetailCodes.Contains(detailCode, StringComparer.OrdinalIgnoreCase);
    }
}