using Hackathon.Service.Services;
using Hackathon.Service.Services.Interfaces;

namespace Hackathon.Service.Extensions;

public static partial class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IVenueService, VenueService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITenantService, TenantService>();
        services.AddScoped<IUserSeedService, UserSeedService>();
    }
}