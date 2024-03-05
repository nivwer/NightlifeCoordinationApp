using NightlifeCoordinationSPA.Dtos;

namespace NightlifeCoordinationSPA.Services.Business;

public interface IBusinessService
{
    Task<BusinessResponseDTO> GetById();
    Task<BusinessListResponseDTO> GetList();
}
