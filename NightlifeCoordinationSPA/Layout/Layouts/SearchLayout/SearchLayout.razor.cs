using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;
using NightlifeCoordinationSPA.Helpers.QueryStringBuilder;

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

    [Parameter]
    [SupplyParameterFromQuery(Name = "price")]
    public string? Price { get; set; }

    protected override void OnParametersSet()
    {
        Model.Keyword = Keyword ?? string.Empty;
        Model.Location = Location ?? string.Empty;
        Model.Price = Price?.Split(',').Select(p => int.Parse(p)).ToArray() ?? [];
    }

    public void OnValidSubmit()
    {
        if (Model != null && !string.IsNullOrWhiteSpace(Model.Keyword))
        {
            if (string.IsNullOrWhiteSpace(Model.Location))
            {
                Model.Location = "New York, NY, United States";
            }

            StateHasChanged();

            string path = "/results";
            var query = new QueryStringBuilder();

            query.AppendParam("query", Model.Keyword);
            query.AppendParam("location", Model.Location);
            query.AppendParam("price", Model.Price);

            Navigate!.NavigateTo($"{path}{query.Get()}");
        }
    }
}