using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListVenueReservationResult
{
    /// <summary>
    /// Data: An array of Venue reservations data
    /// </summary>
    [JsonPropertyName("data")]
    public List<ListVenueReservationResultData> Data { get; set; } = new List<ListVenueReservationResultData>();

    /// <summary>
    /// Count: The number of Venue reservations in the data array
    /// </summary>
    [JsonPropertyName("count")]
    public int Count => Data.Count;
}