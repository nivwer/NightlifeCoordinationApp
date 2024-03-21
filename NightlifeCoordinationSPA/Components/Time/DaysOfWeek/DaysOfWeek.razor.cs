using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Components.Time.DaysOfWeek;

public partial class DaysOfWeek
{
    [Parameter]
    public required OpenHours OpenHours { get; set; }
}