using Hackathon.Service.ApiRequests.Models;
using Hackathon.Service.DAL.Entities.Models;
using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiRequests;

public class VenueCreateRequest
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
    /// Capacity: Capacity of a whole Venue
    /// </summary>
    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }

    /// <summary>
    /// IsRentable: IsRentable flag of a Venue
    /// </summary>
    [JsonPropertyName("isRentable")]
    public bool IsRentable { get; set; }

    /// <summary>
    /// Location: Location of a Venue
    /// </summary>
    [JsonPropertyName("location")]
    public Location Location { get; set; }

    /// <summary>
    /// Rooms: Venue rooms
    /// </summary>
    [JsonPropertyName("rooms")]
    public List<VenueRoom>? Rooms { get; set; }
}
