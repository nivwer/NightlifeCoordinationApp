using System.Net;
using Microsoft.AspNetCore.Mvc;
using NightlifeCoordinationAPI.DTOs.BusinessDTOs;
using NightlifeCoordinationAPI.DTOs.YelpAPIDTOs;
using NightlifeCoordinationAPI.Services.YelpAPIService;

namespace NightlifeCoordinationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessController : ControllerBase
{
    private readonly IYelpAPIService YelpAPIService;

    public BusinessController(IYelpAPIService yelpAPIService)
    {
        YelpAPIService = yelpAPIService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id, [FromQuery] BusinessQueryParamsDTO queryParams)
    {
        var response = await YelpAPIService.GetBusinessById(id, queryParams);

        if (!response.IsSuccessStatusCode)
        {
            var oError = await response.Content.ReadFromJsonAsync<YelpAPIErrorResponseDTO>();

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return new ObjectResult(oError) { StatusCode = 400 };
                case HttpStatusCode.Unauthorized:
                    return new ObjectResult(oError) { StatusCode = 401 };
                case HttpStatusCode.Forbidden:
                    return new ObjectResult(oError) { StatusCode = 403 };
                case HttpStatusCode.NotFound:
                    return new ObjectResult(oError) { StatusCode = 404 };
                case HttpStatusCode.RequestEntityTooLarge:
                    return new ObjectResult(oError) { StatusCode = 413 };
                case HttpStatusCode.TooManyRequests:
                    return new ObjectResult(oError) { StatusCode = 429 };
                case HttpStatusCode.InternalServerError:
                    return new ObjectResult(oError) { StatusCode = 500 };
                case HttpStatusCode.ServiceUnavailable:
                    return new ObjectResult(oError) { StatusCode = 503 };
                default:
                    return new ObjectResult(oError) { StatusCode = 500 };
            }
        }

        var oResponse = await response.Content.ReadFromJsonAsync<YelpAPIBusinessResponseDTO>();

        return Ok(oResponse);
    }



    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] BusinessListQueryParamsDTO queryParams)
    {
        var response = await YelpAPIService.GetListBusinesses(queryParams);

        if (!response.IsSuccessStatusCode)
        {
            var oError = await response.Content.ReadFromJsonAsync<YelpAPIErrorResponseDTO>();

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return new ObjectResult(oError) { StatusCode = 400 };
                case HttpStatusCode.Unauthorized:
                    return new ObjectResult(oError) { StatusCode = 401 };
                case HttpStatusCode.Forbidden:
                    return new ObjectResult(oError) { StatusCode = 403 };
                case HttpStatusCode.NotFound:
                    return new ObjectResult(oError) { StatusCode = 404 };
                case HttpStatusCode.PreconditionFailed:
                    return new ObjectResult(oError) { StatusCode = 412 };
                case HttpStatusCode.TooManyRequests:
                    return new ObjectResult(oError) { StatusCode = 429 };
                case HttpStatusCode.InternalServerError:
                    return new ObjectResult(oError) { StatusCode = 500 };
                case HttpStatusCode.ServiceUnavailable:
                    return new ObjectResult(oError) { StatusCode = 503 };
                default:
                    return new ObjectResult(oError) { StatusCode = 500 };
            }
        }

        var oResponse = await response.Content.ReadFromJsonAsync<YelpAPIBusinessesResponseDTO>();

        return Ok(oResponse);
    }
}
