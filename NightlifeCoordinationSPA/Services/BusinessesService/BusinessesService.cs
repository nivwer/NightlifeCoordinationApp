using System.Net.Http.Json;
using System.Text;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;

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


    // AGREGAR PARAMETROS

    public async Task<BusinessResponseDTO> GetById()
    {
        string uri = BasePath;

        var response = await Http.GetAsync(uri);

        var oResponse = await response.Content.ReadFromJsonAsync<BusinessResponseDTO>()
            ?? new BusinessResponseDTO();

        if (!response.IsSuccessStatusCode)
            return oResponse;

        oResponse.Success = true;

        return oResponse;
    }

    public async Task<BusinessListResponseDTO> GetList(BusinessListQueryDTO queryParams)
    {
        var uri = new StringBuilder(BasePath);
        var query = new StringBuilder();

        AppendParam(query, "term", queryParams.Keyword);
        AppendParam(query, "location", queryParams.Location);
        AppendParam<int>(query, "limit", 20);

        if (query.Length > 0)
        {
            query.Length--;
            uri.Append($"?{query.ToString()}");
        }

        var response = await Http.GetAsync(uri.ToString());

        var oResponse = await response.Content.ReadFromJsonAsync<BusinessListResponseDTO>()
            ?? new BusinessListResponseDTO();

        if (!response.IsSuccessStatusCode)
            return oResponse;

        oResponse.Success = true;

        return oResponse;
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