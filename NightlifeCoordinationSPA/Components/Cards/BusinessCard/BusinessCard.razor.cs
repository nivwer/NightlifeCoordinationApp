using Microsoft.AspNetCore.Components;
using NightlifeCoordinationSPA.Models;

namespace NightlifeCoordinationSPA.Components.Cards.BusinessCard;

public partial class BusinessCard
{
    [Parameter]
    public required Business business { get; set; }
}