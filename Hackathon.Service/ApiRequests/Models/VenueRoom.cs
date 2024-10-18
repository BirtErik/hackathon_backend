using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiRequests.Models;

public class VenueRoom
{
    /// <summary>
    /// Name: Name of a Venue Room
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description: Description of a Venue Room
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Capacity: Capacity of a Venue Room
    /// </summary>
    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    /// <summary>
    /// IsRentable: IsRentable flag of a Venue Room
    /// </summary>
    [JsonPropertyName("isRentable")]
    public bool IsRentable { get; set; }
}