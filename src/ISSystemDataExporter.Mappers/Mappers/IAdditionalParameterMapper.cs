using Destination = ISSystemDataExporter.Models.Storelocator.Companydetail;
using Source = ISSystemDataExporter.Models.ISSystem.AdditionalParameter;

namespace ISSystemDataExporter.Mappers.Mappers;

public interface IAdditionalParameterMapper : IMapper<Source, Destination>
{   
}
