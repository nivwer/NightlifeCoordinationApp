namespace NightlifeCoordinationAPI.Services.YelpAPIService;

public class YelpAPIService : IYelpAPIService
{
    private readonly IHttpClientFactory _http;
    private readonly HttpClient _client;

    public YelpAPIService(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory;
        _client = _http.CreateClient("YelpAPI");
    }

    public async Task test()
    {
        var client = _http.CreateClient("YelpAPI");
        var result = await client.GetAsync("/resto/de/la/ruta");
        Console.WriteLine(result.StatusCode);
    }

    public async Task<HttpResponseMessage> GetListBusinesses()
    {
        string uri = "v3/businesses/search?location=New%20York%20City&limit=20";
        return await _client.GetAsync(uri);
    }
}
