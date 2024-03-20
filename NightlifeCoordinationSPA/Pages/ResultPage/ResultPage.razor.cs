using System.Globalization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
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

    public static string GetDayAbbreviation(int? day)
    {
        if (!day.HasValue)
        {
            return "";
        }

        string[] daysAbbreviations = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
        string daysAbbreviation = daysAbbreviations[day.Value];

        return daysAbbreviation;
    }

    public static string FormatTime(string time)
    {
        if (time == null)
        {
            return "";
        }

        DateTime parsedTime = DateTime.ParseExact(time, "HHmm", CultureInfo.InvariantCulture);
        string formattedTime = parsedTime.ToString("h:mm tt", CultureInfo.InvariantCulture);

        return formattedTime;
    }

    public static Color IsCurrentDayAndIsOpenNow(int? day, bool? isOpenNow)
    {
        if (!day.HasValue)
        {
            return Color.Default;
        }

        DateTime today = DateTime.Today;
        int currentDayOfWeek = (int)today.DayOfWeek;

        if (day == currentDayOfWeek)
        {
            if (isOpenNow.HasValue && isOpenNow.Value)
            {
                return Color.Success;
            }
            else
            {
                return Color.Error;
            }
        }

        return Color.Default;
    }

}