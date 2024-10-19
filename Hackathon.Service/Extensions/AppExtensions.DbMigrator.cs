using Hackathon.Service.DAL.Interfaces;

namespace Hackathon.Service.Extensions;

public static partial class AppExtensions
{
    public static void UseNpgDbMigrator(this IApplicationBuilder app, string connString)
    {
        IDbMigrator migrator = app.ApplicationServices.GetRequiredService<IDbMigrator>();
        migrator.Migrate(connString);
    }
}
