using NightlifeCoordinationAPI.Dtos;

namespace NightlifeCoordinationAPI.Services.YelpAPIService;

public interface IYelpAPIService
{
    Task<HttpResponseMessage> GetListBusinesses();
}
