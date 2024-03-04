using System.Text;
using NightlifeCoordinationAPI.Dtos;

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

    public async Task<HttpResponseMessage> GetListBusinesses(BusinessListQueryParamsDTO queryParams)
    {
        var uriBuilder = new UriBuilder("v3/businesses/search");
        var sQuery = new StringBuilder();

        if (sQuery.Length > 0) sQuery.Length--;

        uriBuilder.Query = sQuery.ToString();

        return await _client.GetAsync(uriBuilder.Uri);
    }

    private static void AppendParam(StringBuilder sQuery, string parameter, string? s)
    {
        if (!string.IsNullOrEmpty(s))
            sQuery.Append($"{parameter}={Uri.EscapeDataString(s)}&");
    }

    private static void AppendParam<T>(StringBuilder sQuery, string parameter, T? n)
    where T : struct
    {
        if (n != null)
            sQuery.Append($"{parameter}={n}&");
    }

    private static void AppendParam(StringBuilder sQuery, string parameter, string[]? a)
    {
        if (a != null && a.Length > 0)
        {
            string sArray = string.Join(",", a);
            sQuery.Append($"{parameter}={Uri.EscapeDataString(sArray)}&");
        }
    }

    private static void AppendParam<T>(StringBuilder sQuery, string parameter, T[]? a)
    where T : struct
    {
        if (a != null && a.Length > 0)
        {
            string sArray = string.Join(",", a);
            sQuery.Append($"{parameter}={Uri.EscapeDataString(sArray)}&");
        }
    }
}
