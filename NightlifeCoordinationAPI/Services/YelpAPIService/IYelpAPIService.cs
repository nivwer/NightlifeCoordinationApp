using NightlifeCoordinationAPI.DTOs.BusinessDTOs;

namespace NightlifeCoordinationAPI.Services.YelpAPIService;

public interface IYelpAPIService
{
    Task<HttpResponseMessage> GetListBusinesses(BusinessListQueryParamsDTO queryParams);
    Task<HttpResponseMessage> GetBusinessById(string id, BusinessQueryParamsDTO queryParams);
}
