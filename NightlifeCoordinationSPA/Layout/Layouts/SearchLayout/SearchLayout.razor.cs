using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.DTOs.SearchDTOs;

namespace NightlifeCoordinationSPA.Layout.Layouts.SearchLayout;

public partial class SearchLayout
{
    public QueryDTO Model = new QueryDTO();

    public bool DrawerOpen = true;

    [Inject]
    public NavigationManager? Navigate { get; set; }

    // protected override async Task OnInitializedAsync()
    // {
    // CARGAR LOS PARAMS
    // }

    public void OnValidSubmit()
    {
        if (Model != null && !string.IsNullOrWhiteSpace(Model.Keyword))
        {
            StateHasChanged();
            Navigate!.NavigateTo($"/results?query={Model.Keyword}&location={Model.Location}");
        }
    }
}