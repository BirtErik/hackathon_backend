using System.Text.Json.Serialization;

namespace Hackathon.Service.ApiResults;

public class ListTenantItemResult
{
    /// <summary>
    /// Data: An array of Tenant data
    /// </summary>
    [JsonPropertyName("data")]
    public List<ListTenantItemResultData> Data { get; set; } = new List<ListTenantItemResultData>();

    /// <summary>
    /// Count: The number of Tenants in the data array
    /// </summary>
    [JsonPropertyName("count")]
    public int Count => Data.Count;
}