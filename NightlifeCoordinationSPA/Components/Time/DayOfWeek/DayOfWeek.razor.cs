using Microsoft.AspNetCore.Components;
using MudBlazor;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Components.Time.DayOfWeek;

public partial class DayOfWeek
{
    [Parameter]
    public required OpenHours OpenHours { get; set; }

    public int[] DaysOfWeekArray = [0, 1, 2, 3, 4, 5, 6];

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

    public static int GetCurrentDayOfWeek()
    {
        DateTime today = DateTime.Today;
        int currentDayOfWeek = (int)today.DayOfWeek;

        return currentDayOfWeek;
    }

    public static bool IsCurrentDay(int day)
    {
        return day == GetCurrentDayOfWeek();
    }
}