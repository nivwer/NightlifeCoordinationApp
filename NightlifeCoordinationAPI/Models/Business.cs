using System.Text.Json.Serialization;

namespace NightlifeCoordinationAPI.Models;

public class Business
{
    public string? Alias { get; set; }
    public List<Category>? Categories { get; set; }
    public Coordinates? Coordinates { get; set; }

    [JsonPropertyName("display_phone")]
    public string? DisplayPhone { get; set; }

    public double? Distance { get; set; }
    public string? Id { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("is_closed")]
    public bool? IsClosed { get; set; }

    public Location? Location { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Price { get; set; }
    public double? Rating { get; set; }

    [JsonPropertyName("review_count")]
    public int? ReviewCount { get; set; }

    
    public string[]? Transactions { get; set; }
    public string? Url { get; set; }
}
