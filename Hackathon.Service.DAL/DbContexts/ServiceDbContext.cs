using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Service.DAL.DbContexts;

public class ServiceDbContext : BaseDbContext<ServiceDbContext>
{
    private readonly IUserResolver userResolver;
    public UserInfo? UserInfo { get; private set; }

    public ServiceDbContext(DbContextOptions<ServiceDbContext> options, IUserResolver? userResolver = null)
        : base(options)
    {
        if (userResolver != null)
        {
            UserInfo = userResolver.GetCurrentUserInfo();
        }
    }

    public ServiceDbContext(DbContextOptions<ServiceDbContext> options, string connString)
        : base(options)
    {
        Database.SetConnectionString(connString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureQueryFilters(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureQueryFilters(ModelBuilder modelBuilder)
    {
        if (UserInfo != null)
        {
            if (UserInfo.Roles!.Contains("Supervisor"))
            {
                modelBuilder.Entity<VenueEntity>().HasQueryFilter(v =>
                    v.TenantId == UserInfo.TenantId
                );
            }
        }
    }
}