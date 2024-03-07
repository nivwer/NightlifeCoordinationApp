using System.Net.Http.Json;
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




    // AGREGAR PARAMETROS

    public async Task<BusinessListResponseDTO> GetList()
    {
        string uri = BasePath;

        uri += "?location=NYC&limit=20";

        var response = await Http.GetAsync(uri);

        var oResponse = await response.Content.ReadFromJsonAsync<BusinessListResponseDTO>()
            ?? new BusinessListResponseDTO();

        if (!response.IsSuccessStatusCode)
            return oResponse;

        oResponse.Success = true;

        return oResponse;
    }
}