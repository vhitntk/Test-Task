using Destination = ISSystemDataExporter.Models.Storelocator.Address;
using Source = ISSystemDataExporter.Models.ISSystem.Address;

namespace ISSystemDataExporter.Mappers.Mappers;

public interface IAddressMapper : IMapper<Source, Destination>
{
}
