using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListVenueItemResult
{
    /// <summary>
    /// Data: An array of Venue data
    /// </summary>
    [JsonPropertyName("data")]
    public List<ListVenueItemResultData> Data { get; set; } = new List<ListVenueItemResultData>();

    /// <summary>
    /// Count: The number of Venues in the data array
    /// </summary>
    [JsonPropertyName("count")]
    public int Count => Data.Count;
}