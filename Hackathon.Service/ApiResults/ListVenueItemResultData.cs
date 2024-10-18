using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListVenueItemResultData
{
    /// <summary>
    /// Id: Unique identifier of a Venue
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Name: Name of a Venue
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}