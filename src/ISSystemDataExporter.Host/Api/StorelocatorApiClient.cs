using ISSystemDataExporter.Models.Storelocator;
using System.Text.Json;

namespace ISSystemDataExporter.Host.Api;

//Набросок клиента для экспорта преобразованных данных в storelocator
public class StorelocatorApiClient : ApiClientBase, IStorelocatorApiClient
{
    public StorelocatorApiClient(ILogger<StorelocatorApiClient> logger, HttpClient httpClient) : base(logger, httpClient)
    {
    }

    public async Task<TResponse?> ExportCompany<TResponse>(Company company, CancellationToken cancellationToken)
    {
        var uri = "companies";
        try
        {
            await using var responseStream = await PostAsync(uri, company, cancellationToken);
            return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occured during Company export, message: {errorMessage}", ex.Message);
            throw;
        }        
    }
}
