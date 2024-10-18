using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiRequests.Models;

public class KeycloakUserResult
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}

