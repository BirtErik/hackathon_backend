using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;

namespace Hackathon.Service.Services.Interfaces;

public interface ITenantService
{
    Task<Guid> CreateTenantAsync(TenantCreateRequest request);

    Task<ListTenantItemResult> ListAllItemsAsync();
}
