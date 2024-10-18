using Hackathon.Service.DAL.Constants;
using Hackathon.Service.DAL.DbContexts;
using Hackathon.Service.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Hackathon.Service.DAL.Core;

public class NpgDbMigrator : IDbMigrator
{
    public ServiceDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<ServiceDbContext> builder = new();
        builder.UseNpgsql();

        return new ServiceDbContext(builder.Options);
    }

    public void Migrate(string connString)
    {
        IEnumerable<string> pendingMigrations = MigrateDatabase(connString);

        if (pendingMigrations.Any())
        {
            foreach (string migration in pendingMigrations)
                Log.Information($"Applying migration '{migration}'.");
        }
        else
        {
            Log.Information("No migrations were applied. The database is already up to date.");
        }

        Log.Information($"Done.");
    }

    private static IEnumerable<string> MigrateDatabase(string connString)
    {
        DbContextOptionsBuilder<ServiceDbContext> builder = new();
        builder.UseNpgsql(connString, x =>
        x.MigrationsHistoryTable("__EFMigrationsHistory", DbSchemaConstants.DefaultDbSchema));

        ServiceDbContext db = new(builder.Options, connString: connString);

        IEnumerable<string> pendingMigrations = db.Database.GetPendingMigrations();
        if (pendingMigrations.Any())
            db.Database.Migrate();

        return pendingMigrations;
    }
}
