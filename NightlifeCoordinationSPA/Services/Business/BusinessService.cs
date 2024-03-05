using System.Net.Http.Json;
using NightlifeCoordinationSPA.Dtos;

namespace NightlifeCoordinationSPA.Services.Business;

public class BusinessService : IBusinessService
{
    private readonly HttpClient _http;
    private readonly string _basePath;

    public BusinessService(HttpClient http)
    {
        _http = http;
        _basePath = "/api/business";
    }


    // AGREGAR PARAMETROS

    public async Task<BusinessResponseDTO> GetById()
    {
        string uri = _basePath;

        var response = await _http.GetAsync(uri);

        var oResponse = await response.Content.ReadFromJsonAsync<BusinessResponseDTO>()
            ?? new BusinessResponseDTO();

        if (!response.IsSuccessStatusCode)
            return oResponse;

        oResponse.Success = true;

        return oResponse;
    }




    // AGREGAR PARAMETROS

    public async Task<BusinessListResponseDTO> GetList()
    {
        string uri = _basePath;

        var response = await _http.GetAsync(uri);

        var oResponse = await response.Content.ReadFromJsonAsync<BusinessListResponseDTO>()
            ?? new BusinessListResponseDTO();

        if (!response.IsSuccessStatusCode)
            return oResponse;

        oResponse.Success = true;

        return oResponse;
    }
}