using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;

namespace NightlifeCoordinationSPA.Layout.Layouts.SearchLayout;

public partial class SearchLayout
{
    public BusinessListQueryDTO Model = new BusinessListQueryDTO();

    public bool DrawerOpen = true;

    [Inject]
    public NavigationManager? Navigate { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "query")]
    public string? Keyword { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "location")]
    public string? Location { get; set; }

    protected override void OnParametersSet()
    {
        Model.Keyword = Keyword ?? string.Empty;
        Model.Location = Location ?? string.Empty;
    }

    public void OnValidSubmit()
    {
        if (Model != null && !string.IsNullOrWhiteSpace(Model.Keyword))
        {
            if (string.IsNullOrWhiteSpace(Model.Location))
                Model.Location = "New York, NY, United States";

            StateHasChanged();
            Navigate!.NavigateTo($"/results?query={Model.Keyword}&location={Model.Location}");
        }
    }
}