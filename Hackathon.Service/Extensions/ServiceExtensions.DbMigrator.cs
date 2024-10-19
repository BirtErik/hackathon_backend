using Hackathon.Service.DAL.Core;
using Hackathon.Service.DAL.Interfaces;

namespace Hackathon.Service.Extensions;

public static partial class ServiceExtensions
{
    public static void ConfigureNpgDbMigrator(this IServiceCollection services)
    {
        services.AddSingleton<IDbMigrator, NpgDbMigrator>();
    }
}
