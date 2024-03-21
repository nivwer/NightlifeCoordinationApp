using System.Globalization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Components.Time.Schedule;

public partial class Schedule
{
    [Parameter]
    public required OpenTime OpenTime { get; set; }

    [Parameter]
    public bool? IsOpenNow { get; set; }

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

    public Color GetTextColorByDay(int? day)
    {
        if (!day.HasValue || !IsCurrentDay(day.Value))
        {
            return Color.Default;
        }

        if (IsOpenNow.HasValue && IsOpenNow.Value)
        {
            return Color.Success;
        }
        else
        {
            return Color.Error;
        }
    }

    private Color GetTextColorByTime(int? day, string startTime, string endTime)
    {
        if (startTime == null || endTime == null || !day.HasValue || !IsCurrentDay(day.Value))
        {
            return Color.Default;
        }

        DateTime currentTime = DateTime.Now;
        DateTime start = DateTime.ParseExact(startTime, "HHmm", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(endTime, "HHmm", CultureInfo.InvariantCulture);

        if (currentTime >= start && currentTime <= end)
        {
            if (IsOpenNow.HasValue && IsOpenNow.Value)
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