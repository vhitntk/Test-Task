using Destination = ISSystemDataExporter.Models.Storelocator.Company;
using Source = ISSystemDataExporter.Models.ISSystem.CompanyPropertyContainer;

namespace ISSystemDataExporter.Mappers.Mappers;

public interface ICompanyMapper : IMapper<Source, Destination>
{
}
