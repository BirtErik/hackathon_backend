using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Service.Services;

public class TenantService : ITenantService
{
    private readonly IServiceRepository Repo;

    public TenantService(IServiceRepository repo)
    {
        Repo = repo;
    }

    public async Task<Guid> CreateTenantAsync(TenantCreateRequest request)
    {
        TenantEntity tenantEntity = new()
        {
            Name = request.Name!,
            Description = request.Description!,
        };

        await Repo.InsertAsync(tenantEntity);
        await Repo.SaveChangesAsync();

        return tenantEntity.Id;
    }

    public async Task<ListTenantItemResult> ListAllItemsAsync()
    {
        var tenantQuery = Repo.AsQueryable<TenantEntity>().AsNoTracking();

        List<TenantEntity> tenants = await tenantQuery
            .OrderBy(x => x.Name)
            .ToListAsync();

        List<ListTenantItemResultData> tenantItems = tenants.Select(x => new ListTenantItemResultData
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();

        ListTenantItemResult result = new()
        {
            Data = tenantItems,
        };

        return result;
    }
}
