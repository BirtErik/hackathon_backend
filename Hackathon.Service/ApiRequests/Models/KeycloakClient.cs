using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiRequests.Models;

public class KeycloakClient
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("clientId")]
    public string ClientId { get; set; }
}
