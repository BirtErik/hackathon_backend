using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListVenueResult
{
    /// <summary>
    /// Data: An array of Venues data
    /// </summary>
    [JsonPropertyName("data")]
    public List<ListVenueResultData> Data { get; set; } = new List<ListVenueResultData>();

    /// <summary>
    /// Count: The number of Venues in the data array
    /// </summary>
    [JsonPropertyName("count")]
    public int Count => Data.Count;

    /// <summary>
    /// Total: The number of Venues in the database
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}