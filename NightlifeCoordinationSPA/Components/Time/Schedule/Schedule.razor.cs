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

    [Parameter]
    public bool OnlyOpen { get; set; }

    [Parameter]
    public bool ColorOpen { get; set; } = true;

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


    public bool IsOpenNowByTime()
    {
        if (
            OpenTime.Start == null || OpenTime.End == null
            || !OpenTime.Day.HasValue || !IsCurrentDay(OpenTime.Day.Value)
        )
        {
            return false;
        }

        DateTime currentTime = DateTime.Now;
        DateTime start = DateTime.ParseExact(OpenTime.Start, "HHmm", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(OpenTime.End, "HHmm", CultureInfo.InvariantCulture);

        if (OpenTime.IsOvernight.HasValue && OpenTime.IsOvernight.Value)
        {
            if (currentTime >= start && currentTime <= end.AddDays(1))
            {
                return true;
            }
        }
        else
        {
            if (
                currentTime >= start && ((currentTime <= end)
                || (end.Hour == 0 && end.Minute == 0 && currentTime <= end.AddDays(1)))
            )
            {
                return true;
            }
        }

        return false;
    }

    public Color GetTextColorByTime()
    {
        if (!IsOpenNowByTime() || !ColorOpen)
        {
            return Color.Default;
        }

        return Color.Success;
    }
}