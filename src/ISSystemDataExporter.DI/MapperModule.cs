using ISSystemDataExporter.Mappers.Mappers;
using ISSystemDataExporter.Mappers.Mappers.Impl;
using ISSystemDataExporter.Mappers.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace ISSystemDataExporter.DI;

public static class MapperModule
{
    public static IServiceCollection RegisterMappers(this IServiceCollection services)
    {
        services.AddSingleton<IXMLContentParser, XMLContentParser>();

        services.AddSingleton<IDictionaryItemMapper, DictionaryItemMapper>();
        services.AddSingleton<IAdditionalParameterMapper, AdditionalParameterMapper>();
        services.AddSingleton<IAddressMapper, AddressMapper>();
        services.AddSingleton<ICompanyMapper, CompanyMapper>();
        
        return services;
    }
}
