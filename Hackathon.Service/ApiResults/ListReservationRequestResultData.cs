using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListReservationRequestResultData
{
    /// <summary>
    /// Id: Unique identifier of a Reservation Request
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    [JsonPropertyName("streetAddress")]
    public required string StreetAddress { get; set; }

    [JsonPropertyName("city")]
    public required string City { get; set; }

    [JsonPropertyName("oib")]
    public required string Oib { get; set; }

    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    [JsonPropertyName("bankName")]
    public required string BankName { get; set; }

    [JsonPropertyName("iban")]
    public required string Iban { get; set; }

    [JsonPropertyName("purpose")]
    public required string Purpose { get; set; }

    [JsonPropertyName("startDate")]
    public DateTimeOffset StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset EndDate { get; set; }
}
