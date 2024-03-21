using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;
using NightlifeCoordinationSPA.Services.BusinessesService;

namespace NightlifeCoordinationSPA.Pages.ResultPage;

public partial class ResultPage
{
    public BusinessResponseDTO Model = new BusinessResponseDTO();

    public bool DrawerOpen = true;

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IBusinessesService? BusinessesService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }

    [Parameter]
    public required string Id { get; set; }

    protected override async void OnParametersSet()
    {
        ShowErrorMessage = false;

        if (BusinessesService != null && !string.IsNullOrEmpty(Id))
        {
            var response = await BusinessesService.GetById(Id);

            if (!response.Success)
            {
                ShowErrorMessage = true;
                string message = "An unexpected error occurred.";
                ErrorMessage = response.Error?.Description ?? message;
            }
            else
            {
                Model = response;
                StateHasChanged();
            }
        }
    }
}