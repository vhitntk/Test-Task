using Destination = ISSystemDataExporter.Models.Storelocator.DictionaryItem;
using Source = ISSystemDataExporter.Models.ISSystem.DictionaryItem;

namespace ISSystemDataExporter.Mappers.Mappers;

public interface IDictionaryItemMapper : IMapper<Source, Destination>
{
}
