using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiRequests.Models;

public class KeycloakRole
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
