using Hackathon.Service.ApiRequests.Models;
using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiRequests;

public class VenueUpdateRequest
{
    /// <summary>
    /// Name: Name of a Venue
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description: Description of a Venue
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// IsRentable: IsRentable flag of a Venue
    /// </summary>
    [JsonPropertyName("isRentable")]
    public bool IsRentable { get; set; }

    /// <summary>
    /// Rooms: Venue rooms
    /// </summary>
    [JsonPropertyName("rooms")]
    public List<VenueRoom>? Rooms { get; set; }
}
