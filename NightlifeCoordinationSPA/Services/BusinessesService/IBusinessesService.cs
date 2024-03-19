using NightlifeCoordinationSPA.DTOs.BusinessDTOs;

namespace NightlifeCoordinationSPA.Services.BusinessesService;

public interface IBusinessesService
{
    Task<BusinessResponseDTO> GetById(string Id);
    Task<BusinessListResponseDTO> GetList(BusinessListQueryDTO queryParams);
}
