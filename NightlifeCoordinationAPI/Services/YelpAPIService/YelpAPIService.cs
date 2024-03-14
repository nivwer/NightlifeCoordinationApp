using System.Text;
using NightlifeCoordinationAPI.DTOs.BusinessDTOs;
using NightlifeCoordinationAPI.Helpers.QueryStringBuilder;

namespace NightlifeCoordinationAPI.Services.YelpAPIService;

public class YelpAPIService : IYelpAPIService
{
    private readonly IHttpClientFactory Http;
    private readonly HttpClient Client;

    public YelpAPIService(IHttpClientFactory httpClientFactory)
    {
        Http = httpClientFactory;
        Client = Http.CreateClient("YelpAPI");
    }

    public async Task<HttpResponseMessage> GetBusinessById(string id, BusinessQueryParamsDTO queryParams)
    {
        string path = $"v3/businesses/{id}";
        var query = new QueryStringBuilder();

        query.AppendParam("locale", queryParams.Locale);
        query.AppendParam("device_platform", queryParams.DevicePlatform);

        return await Client.GetAsync($"{path}{query.Get()}");
    }

    public async Task<HttpResponseMessage> GetListBusinesses(BusinessListQueryParamsDTO queryParams)
    {
        string path = "v3/businesses/search";
        var query = new QueryStringBuilder();

        query.AppendParam("location", queryParams.Location);
        query.AppendParam("latitude", queryParams.Latitude);
        query.AppendParam("longitude", queryParams.Longitude);
        query.AppendParam("term", queryParams.Term);
        query.AppendParam("radius", queryParams.Radius);
        query.AppendParam("categories", queryParams.Categories);
        query.AppendParam("locale", queryParams.Locale);
        query.AppendParam("price", queryParams.Price);
        query.AppendParam("open_now", queryParams.OpenNow);
        query.AppendParam("open_at", queryParams.OpenAt);
        query.AppendParam("attributes", queryParams.Attributes);
        query.AppendParam("sort_by", queryParams.SortBy);
        query.AppendParam("device_platform", queryParams.DevicePlatform);
        query.AppendParam("reservation_date", queryParams.ReservationDate);
        query.AppendParam("reservation_time", queryParams.ReservationTime);
        query.AppendParam("reservation_covers", queryParams.ReservationCovers);
        query.AppendParam("matches_party_size_param", queryParams.MatchesPartySizeParam);
        query.AppendParam<int>("limit", queryParams.Limit);
        query.AppendParam("offset", queryParams.Offset);

        return await Client.GetAsync($"{path}{query.Get()}");
    }
}
