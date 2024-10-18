using System.Text.Json.Serialization;
using System.Text.Json;

namespace Hackathon.Service.ApiResults;

public class ErrorDetailsResult
{

    /// <summary>
    /// ErrorMessage: The error message describing the error that occurred
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; set; } = null!;

    /// <summary>
    /// MoreInfo: More information about the error
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("moreInfo")]
    public string? MoreInfo { get; set; }

    /// <summary>
    /// StatusCode: The HTTP status code returned for the error
    /// </summary>
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// ErrorCode: A unique error code for the error that occurred
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; set; } = null!;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
