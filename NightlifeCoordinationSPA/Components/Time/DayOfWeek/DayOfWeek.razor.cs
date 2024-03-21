using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Components.Time.DayOfWeek;

public partial class DayOfWeek
{
    [Parameter]
    public required OpenHours OpenHours { get; set; }

    public static int GetCurrentDayOfWeek()
    {
        DateTime today = DateTime.Today;
        int currentDayOfWeek = (int)today.DayOfWeek;

        return currentDayOfWeek;
    }

    public static bool IsCurrentDay(int? day)
    {
        if (!day.HasValue)
        {
            return false;
        }

        return day == GetCurrentDayOfWeek();
    }
}