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

    /// <summary>
    /// Location: Capacity of a Venue
    /// </summary>
    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }

    /// <summary>
    /// Price: Price of a Venue rent
    /// </summary>
    [JsonPropertyName("price")]
    public double Price { get; set; }

    /// <summary>
    /// SecurityDeposit: Security deposit for a Venue reservation
    /// </summary>
    [JsonPropertyName("securityDeposit")]
    public double SecurityDeposit { get; set; }
}
