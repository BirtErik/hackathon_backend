using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListTenantItemResultData
{
    /// <summary>
    /// Id: Unique identifier of a Tenant
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Name: Name of a Tenant
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}