using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;
using NightlifeCoordinationSPA.Models;
using NightlifeCoordinationSPA.Services.BusinessesService;

namespace NightlifeCoordinationSPA.Pages.ResultsPage;

public partial class ResultsPage
{
    public List<Business> Businesses = new List<Business>();

    public BusinessListQueryDTO QueryParams = new BusinessListQueryDTO();

    public bool ShowErrorMessage { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IBusinessesService? BusinessesService { get; set; }

    [Inject]
    public NavigationManager? Navigate { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "query")]
    public string? KeywordQueryParam { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "location")]
    public string? LocationQueryParam { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "price")]
    public int[]? PriceQueryParam { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "open_now")]
    public bool? OpenNowQueryParam { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "attributes")]
    public string[]? AttributesQueryParam { get; set; }

    protected override async void OnParametersSet()
    {
        ShowErrorMessage = false;

        if (
            BusinessesService != null
            && !string.IsNullOrWhiteSpace(KeywordQueryParam)
            && !string.IsNullOrWhiteSpace(LocationQueryParam)
        )
        {
            QueryParams.Keyword = KeywordQueryParam;
            QueryParams.Location = LocationQueryParam;
            QueryParams.Price = PriceQueryParam;
            QueryParams.OpenNow = OpenNowQueryParam;
            QueryParams.Attributes = AttributesQueryParam;

            var response = await BusinessesService.GetList(QueryParams);

            if (!response.Success)
            {
                ShowErrorMessage = true;
                string message = "An unexpected error occurred.";
                ErrorMessage = response.Error?.Description ?? message;
            }
            else
            {
                Businesses = response.Businesses ?? Businesses;
                StateHasChanged();
            }
        }
    }
}
