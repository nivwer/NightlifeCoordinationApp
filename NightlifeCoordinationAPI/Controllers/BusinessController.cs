using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NightlifeCoordinationAPI.Dtos;
using NightlifeCoordinationAPI.Services.YelpAPIService;

namespace NightlifeCoordinationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessController : ControllerBase
{
    private readonly IYelpAPIService _yelpAPIService;

    public BusinessController(IYelpAPIService yelpAPIService)
    {
        _yelpAPIService = yelpAPIService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetList()
    {
        var response = await _yelpAPIService.GetListBusinesses();

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
                    return new ObjectResult(oError) { StatusCode = 412 };
                case HttpStatusCode.InternalServerError:
                    return new ObjectResult(oError) { StatusCode = 500 };
                case HttpStatusCode.ServiceUnavailable:
                    return new ObjectResult(oError) { StatusCode = 503 };
                default:
                    return new ObjectResult(oError) { StatusCode = 500 };
            }
        }

        var oResponse = await response.Content.ReadFromJsonAsync<YelpAPIResponseDTO>();

        return Ok(oResponse);
    }
}
