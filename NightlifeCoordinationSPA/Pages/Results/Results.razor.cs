using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Models;
using NightlifeCoordinationSPA.Services.Business;

namespace NightlifeCoordinationSPA.Pages.Results;

public partial class Results
{
    public List<Business> _businesses = new List<Business>();

    [Inject]
    private IBusinessService? _businessService { get; set; }

    [Inject]
    public NavigationManager? _navigate { get; set; }

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }


    protected override async Task OnInitializedAsync()
    {
        ShowErrorMessage = false;

        if (_businessService != null)
        {
            var response = await _businessService.GetList();

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
                    _businesses = response.Businesses;
                    
                StateHasChanged();
            }
        }
    }
}
