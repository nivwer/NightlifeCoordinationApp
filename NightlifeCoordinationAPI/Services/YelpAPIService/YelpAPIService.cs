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

        AppendParam(sQuery, "location", queryParams.Location);
        AppendParam(sQuery, "latitude", queryParams.Latitude);
        AppendParam(sQuery, "longitude", queryParams.Longitude);
        AppendParam(sQuery, "term", queryParams.Term);
        AppendParam(sQuery, "radius", queryParams.Radius);
        AppendParam(sQuery, "categories", queryParams.Categories);
        AppendParam(sQuery, "locale", queryParams.Locale);
        AppendParam(sQuery, "price", queryParams.Price);
        AppendParam(sQuery, "open_now", queryParams.OpenNow);
        AppendParam(sQuery, "open_at", queryParams.OpenAt);
        AppendParam(sQuery, "attributes", queryParams.Attributes);
        AppendParam(sQuery, "sort_by", queryParams.SortBy);
        AppendParam(sQuery, "device_platform", queryParams.DevicePlatform);
        AppendParam(sQuery, "reservation_date", queryParams.ReservationDate);
        AppendParam(sQuery, "reservation_time", queryParams.ReservationTime);
        AppendParam(sQuery, "reservation_covers", queryParams.ReservationCovers);
        AppendParam(sQuery, "matches_party_size_param", queryParams.MatchesPartySizeParam);
        AppendParam<int>(sQuery, "limit", queryParams.Limit);
        AppendParam(sQuery, "offset", queryParams.Offset);

        if (sQuery.Length > 0) sQuery.Length--;

        uriBuilder.Query = sQuery.ToString();

        return await _client.GetAsync(uriBuilder.Uri);
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
