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

    public async Task<HttpResponseMessage> GetBusinessById(string id, BusinessQueryParamsDTO queryParams)
    {
        string uri = $"v3/businesses/{id}";
        var query = new StringBuilder();

        AppendParam(query, "locale", queryParams.Locale);
        AppendParam(query, "device_platform", queryParams.DevicePlatform);

        if (query.Length > 0)
        {
            query.Length--;
            uri += $"?{query}";
        }

        return await _client.GetAsync(uri);
    }

    public async Task<HttpResponseMessage> GetListBusinesses(BusinessListQueryParamsDTO queryParams)
    {
        string uri = "v3/businesses/search";
        var query = new StringBuilder();

        AppendParam(query, "location", queryParams.Location);
        AppendParam(query, "latitude", queryParams.Latitude);
        AppendParam(query, "longitude", queryParams.Longitude);
        AppendParam(query, "term", queryParams.Term);
        AppendParam(query, "radius", queryParams.Radius);
        AppendParam(query, "categories", queryParams.Categories);
        AppendParam(query, "locale", queryParams.Locale);
        AppendParam(query, "price", queryParams.Price);
        AppendParam(query, "open_now", queryParams.OpenNow);
        AppendParam(query, "open_at", queryParams.OpenAt);
        AppendParam(query, "attributes", queryParams.Attributes);
        AppendParam(query, "sort_by", queryParams.SortBy);
        AppendParam(query, "device_platform", queryParams.DevicePlatform);
        AppendParam(query, "reservation_date", queryParams.ReservationDate);
        AppendParam(query, "reservation_time", queryParams.ReservationTime);
        AppendParam(query, "reservation_covers", queryParams.ReservationCovers);
        AppendParam(query, "matches_party_size_param", queryParams.MatchesPartySizeParam);
        AppendParam<int>(query, "limit", queryParams.Limit);
        AppendParam(query, "offset", queryParams.Offset);

        if (query.Length > 0)
        {
            query.Length--;
            uri += $"?{query}";
        }

        return await _client.GetAsync(uri);
    }

    private static void AppendParam(StringBuilder sQuery, string parameter, string? s)
    {
        if (!string.IsNullOrEmpty(s))
            sQuery.Append($"{parameter}={Uri.EscapeDataString(s)}&");
    }

    private static void AppendParam<T>(StringBuilder sQuery, string parameter, T? v)
    where T : struct
    {
        if (v != null)
            sQuery.Append($"{parameter}={v}&");
    }

    private static void AppendParam<T>(StringBuilder sQuery, string parameter, T[]? a)
    {
        if (a != null && a.Length > 0)
        {
            string sArray = string.Join(",", a);
            sQuery.Append($"{parameter}={Uri.EscapeDataString(sArray)}&");
        }
    }
}
