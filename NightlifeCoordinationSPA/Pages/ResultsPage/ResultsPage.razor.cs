using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Models;
using NightlifeCoordinationSPA.Services.BusinessesService;

namespace NightlifeCoordinationSPA.Pages.ResultsPage;

public partial class ResultsPage
{
    public List<Business> Businesses = new List<Business>();

    [Inject]
    public IBusinessesService? BusinessesService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }


    protected override async Task OnInitializedAsync()
    {
        ShowErrorMessage = false;

        if (BusinessesService != null)
        {
            var response = await BusinessesService.GetList();

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
