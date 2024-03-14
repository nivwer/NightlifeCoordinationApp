// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NightlifeCoordinationAPI.Services.YelpAPIService;

// namespace NightlifeCoordinationAPI.Controllers;

// [Route("api/[controller]")]
// [ApiController]
// public class TestController : ControllerBase
// {
//     private readonly IYelpAPIService _yelpAPIService;

//     public TestController(IYelpAPIService yelpAPIService)
//     {
//         _yelpAPIService = yelpAPIService;
//     }

//     [HttpGet]
//     [Authorize]
//     public async Task<IActionResult> GetBusinesses()
//     {
//         await _yelpAPIService.GetBusinesses();
//         return Ok();
//     }
// }
