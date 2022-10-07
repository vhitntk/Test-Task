using ISSystemDataExporter.Models.Storelocator;

namespace ISSystemDataExporter.Host.Api;

public interface IStorelocatorApiClient
{
    Task<TResponse?> ExportCompany<TResponse>(Company company, CancellationToken cancellationToken);
}
