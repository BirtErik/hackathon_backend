using Hackathon.Service.ApiRequests.Models;
using Hackathon.Service.DAL.Entities.Models;
using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class VenueResult
{
    /// <summary>
    /// Id: Unique identifier of the Venue
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    /// <summary>
    /// Name: Name of a Venue
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Description: Description of a Venue
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Capacity: Capacity of a Venue
    /// </summary>
    [JsonPropertyName("capacity")]
    public required int Capacity { get; set; }

    /// <summary>
    /// IsRentable: IsRentable flag of a Venue
    /// </summary>
    [JsonPropertyName("isRentable")]
    public required bool IsRentable { get; set; }

    /// <summary>
    /// Location: Location of a Venue
    /// </summary>
    [JsonPropertyName("location")]
    public required Location Location { get; set; }

    /// <summary>
    /// Rooms: Venue rooms 
    /// </summary>
    [JsonPropertyName("rooms")]
    public required List<VenueRoom> Rooms { get; set; }
}