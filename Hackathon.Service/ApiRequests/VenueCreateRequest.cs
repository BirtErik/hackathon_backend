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
    /// IsRentable: IsRentable flag of a Venue
    /// </summary>
    [JsonPropertyName("isRentable")]
    public bool IsRentable { get; set; }

    /// <summary>
    /// Location: Location of a Venue
    /// </summary>
    [JsonPropertyName("location")]
    public Location Location { get; set; }
}
