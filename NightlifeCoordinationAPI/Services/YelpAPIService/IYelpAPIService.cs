using NightlifeCoordinationAPI.Dtos;

namespace NightlifeCoordinationAPI.Services.YelpAPIService;

public interface IYelpAPIService
{
    Task<HttpResponseMessage> GetListBusinesses(BusinessListQueryParamsDTO queryParams);
    Task<HttpResponseMessage> GetBusinessById(string id, BusinessQueryParamsDTO queryParams);

}
