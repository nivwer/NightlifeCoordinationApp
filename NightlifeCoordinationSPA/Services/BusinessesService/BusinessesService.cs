using System.Net.Http.Json;
using System.Text;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;
using NightlifeCoordinationSPA.Helpers.QueryStringBuilder;

namespace NightlifeCoordinationSPA.Services.BusinessesService;

public class BusinessesService : IBusinessesService
{
    private readonly HttpClient Http;
    private readonly string BasePath;

    public BusinessesService(HttpClient http)
    {
        Http = http;
        BasePath = "/api/business";
    }

    public async Task<BusinessResponseDTO> GetById(string Id)
    {
        string path = BasePath;

        var response = await Http.GetAsync($"{path}/{Id}");

        var oResponse = await response.Content.ReadFromJsonAsync<BusinessResponseDTO>()
            ?? new BusinessResponseDTO();

        if (!response.IsSuccessStatusCode)
        {
            return oResponse;
        }

        oResponse.Success = true;

        return oResponse;
    }

    public async Task<BusinessListResponseDTO> GetList(BusinessListQueryDTO queryParams)
    {
        string path = BasePath;
        var query = new QueryStringBuilder();

        query.AppendParam("term", queryParams.Keyword);
        query.AppendParam("location", queryParams.Location);
        query.AppendParam("price", queryParams.Price);
        query.AppendParam("categories", queryParams.Categories);
        query.AppendParam("open_now", queryParams.OpenNow);
        query.AppendParam("attributes", queryParams.Attributes);
        query.AppendParam("limit", 20);

        var response = await Http.GetAsync($"{path}{query.Get()}");

        var oResponse = await response.Content.ReadFromJsonAsync<BusinessListResponseDTO>()
            ?? new BusinessListResponseDTO();

        if (!response.IsSuccessStatusCode)
        {
            return oResponse;
        }

        oResponse.Success = true;

        return oResponse;
    }
}