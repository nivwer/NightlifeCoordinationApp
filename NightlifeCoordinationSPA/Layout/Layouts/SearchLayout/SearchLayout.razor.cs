using Microsoft.AspNetCore.Components;
using MudBlazor;
using NightlifeCoordinationSPA.DTOs.BusinessDTOs;
using NightlifeCoordinationSPA.Helpers.QueryStringBuilder;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Layout.Layouts.SearchLayout;

public partial class SearchLayout
{
    public BusinessListQueryDTO Model = new BusinessListQueryDTO();

    public bool DrawerOpen = true;

    public bool ReservationCheckBox { get; set; } = false;
    public bool WaitlistReservationCheckBox { get; set; } = false;
    public bool HotAndNewCheckBox { get; set; } = false;
    public bool OpenToAllCheckBox { get; set; } = false;
    public bool WheelchairAccessibleCheckBox { get; set; } = false;
    public bool GenderNeutralRestroomsCheckBox { get; set; } = false;

    public MudChip[] CategoriesSelected = [];

    private readonly List<Category> Categories =
    [
        new Category { Alias = "coffee_and_tea", Title = "Coffee & Tea" },
        new Category { Alias = "ice_cream_and_frozen_yogurt", Title = "Ice Cream & Frozen Yogurt" },
        new Category { Alias = "restaurants", Title = "Restaurants" },
        new Category { Alias = "breakfast_and_brunch", Title = "Breakfast & Brunch" },
        new Category { Alias = "sandwiches", Title = "Sandwiches" },
        new Category { Alias = "bars", Title = "Bars" },
        new Category { Alias = "cocktail_bars", Title = "Cocktail Bars" },
        new Category { Alias = "whiskey_bars", Title = "Whiskey Bars" },
        new Category { Alias = "dance_clubs", Title = "Dance Clubs" },
        new Category { Alias = "lounges", Title = "Lounges" },
        new Category { Alias = "burgers", Title = "Burgers" },
        new Category { Alias = "fast_food", Title = "Fast Food" },
        new Category { Alias = "pizza", Title = "Pizza" }
    ];

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
    [SupplyParameterFromQuery(Name = "categories")]
    public string[]? CategoriesQueryParam { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "open_now")]
    public bool? OpenNowQueryParam { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "attributes")]
    public string[]? AttributesQueryParam { get; set; }

    protected override void OnParametersSet()
    {
        Model.Keyword = KeywordQueryParam ?? string.Empty;
        Model.Location = LocationQueryParam ?? string.Empty;
        Model.Price = PriceQueryParam ?? [];
        Model.OpenNow = OpenNowQueryParam;

        if (AttributesQueryParam != null && AttributesQueryParam.Length > 0)
        {
            ReservationCheckBox = AttributesQueryParam.Contains("reservation");
            WaitlistReservationCheckBox = AttributesQueryParam.Contains("waitlist_reservation");
            HotAndNewCheckBox = AttributesQueryParam.Contains("hot_and_new");
            OpenToAllCheckBox = AttributesQueryParam.Contains("open_to_all");
            WheelchairAccessibleCheckBox = AttributesQueryParam.Contains("wheelchair_accessible");
            GenderNeutralRestroomsCheckBox = AttributesQueryParam.Contains("gender_neutral_restrooms");
        }
    }

    public void OnValidSubmit()
    {
        if (Model != null && !string.IsNullOrWhiteSpace(Model.Keyword))
        {
            if (string.IsNullOrWhiteSpace(Model.Location))
                Model.Location = "New York, NY, United States";

            Model.Attributes = new List<string>();

            if (ReservationCheckBox) Model.Attributes.Append("reservation");
            if (WaitlistReservationCheckBox) Model.Attributes.Append("waitlist_reservation");
            if (HotAndNewCheckBox) Model.Attributes.Append("hot_and_new");
            if (OpenToAllCheckBox) Model.Attributes.Append("open_to_all");
            if (WheelchairAccessibleCheckBox) Model.Attributes.Append("wheelchair_accessible");
            if (GenderNeutralRestroomsCheckBox) Model.Attributes.Append("gender_neutral_restrooms");

            Model.Categories = new List<string>();

            if (CategoriesSelected.Length > 0)
            {
                foreach (var c in CategoriesSelected)
                {
                    Model.Categories.Append(c.Text);
                }
            }

            StateHasChanged();

            string path = "/results";
            var query = new QueryStringBuilder();

            query.AppendParam("query", Model.Keyword);
            query.AppendParam("location", Model.Location);
            query.AppendParam("price", Model.Price);
            query.AppendParam("open_now", Model.OpenNow);
            query.AppendParam("attributes", Model.Attributes);
            query.AppendParam("categories", Model.Categories);

            Navigate!.NavigateTo($"{path}{query.Get()}");
        }
    }

    public void ResetValues()
    {
        Model.Price = null;
        Model.OpenNow = null;
        Model.Attributes = [];

        ReservationCheckBox = false;
        WaitlistReservationCheckBox = false;
        HotAndNewCheckBox = false;
        OpenToAllCheckBox = false;
        WheelchairAccessibleCheckBox = false;
        GenderNeutralRestroomsCheckBox = false;
    }
}