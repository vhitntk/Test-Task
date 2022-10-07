namespace ISSystemDataExporter.Host.Api;

public abstract class ApiClientBase
{
    protected readonly ILogger Logger;
    private readonly HttpClient httpClient;

    protected ApiClientBase(
        ILogger logger,
        HttpClient httpClient)
    {
        Logger = logger;
        this.httpClient = httpClient;
    }

    protected Task<Stream> GetAsync(string requestUri, CancellationToken token = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        return SendAsync(request, token);
    }

    protected Task<Stream> PostAsync<TPayload>(string requestUri, TPayload payload, CancellationToken token = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = JsonContent.Create(payload)
        };

        return SendAsync(request, token);
    }

    private async Task<Stream> SendAsync(HttpRequestMessage request, CancellationToken token = default)
    {
        var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
        return await response.EnsureSuccessStatusCode().Content.ReadAsStreamAsync(token);
    }
}
