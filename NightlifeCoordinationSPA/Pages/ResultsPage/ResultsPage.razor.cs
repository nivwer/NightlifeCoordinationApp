using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;
using NightlifeCoordinationSPA.Models;
using NightlifeCoordinationSPA.Services.BusinessesService;

namespace NightlifeCoordinationSPA.Pages.ResultsPage;

public partial class ResultsPage
{
    public List<Business> Businesses = new List<Business>();

    public BusinessListQueryDTO QueryParams = new BusinessListQueryDTO();

    [Inject]
    public IBusinessesService? BusinessesService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "query")]
    public string? Keyword { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "location")]
    public string? Location { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ShowErrorMessage = false;

        if (BusinessesService != null)
        {
            QueryParams.Keyword = Keyword ?? string.Empty;
            QueryParams.Location = Location ?? string.Empty;

            var response = await BusinessesService.GetList(QueryParams);

            if (!response.Success)
            {
                ShowErrorMessage = true;
                string message = "An unexpected error occurred.";

                if (response.Error != null)
                    ErrorMessage = response.Error.Description ?? message;
                else
                    ErrorMessage = message;
            }
            else
            {
                if (response.Businesses != null)
                    Businesses = response.Businesses;

                StateHasChanged();
            }
        }
    }
}
