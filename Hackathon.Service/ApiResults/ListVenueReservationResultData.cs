using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListVenueReservationResultData
{
    /// <summary>
    /// StartDate: StartDate of a Venue reservation
    /// </summary>
    [JsonPropertyName("startDate")]
    public required DateTimeOffset StartDate { get; set; }

    /// <summary>
    /// EndDate: EndDate of a Venue reservation
    /// </summary>
    [JsonPropertyName("endDate")]
    public required DateTimeOffset EndDate { get; set; }
}
