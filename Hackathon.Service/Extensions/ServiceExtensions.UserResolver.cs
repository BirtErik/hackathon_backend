using Hackathon.Service.DAL.Core;
using Hackathon.Service.DAL.Interfaces;

namespace Hackathon.Service.Extensions;

public static partial class ServiceExtensions
{
    public static void ConfigureUserResolver(this IServiceCollection services)
    {
        services.AddScoped<IUserResolver, UserResolver>();
    }
}
