using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListReservationRequestResult
{
    /// <summary>
    /// Data: An array of Reservation Requests data
    /// </summary>
    [JsonPropertyName("data")]
    public List<ListReservationRequestResultData> Data { get; set; } = new List<ListReservationRequestResultData>();

    /// <summary>
    /// Count: The number of Reservation Requests in the data array
    /// </summary>
    [JsonPropertyName("count")]
    public int Count => Data.Count;

    /// <summary>
    /// Total: The number of Reservation Requests in the database
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}
