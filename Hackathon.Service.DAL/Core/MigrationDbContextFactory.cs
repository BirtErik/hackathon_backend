using Hackathon.Service.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Hackathon.Service.DAL.Core;

internal class MigrationDbContextFactory : IDesignTimeDbContextFactory<ServiceDbContext>
{
    public ServiceDbContext CreateDbContext(string[] args)
    {
        string? connString = GetConnString(args);

        DbContextOptionsBuilder<ServiceDbContext> builder = new();
        builder.UseNpgsql(connString);

        return new ServiceDbContext(builder.Options, connString);
    }

    private static string GetConnString(string[] args)
    {
        string? connString = Environment.GetEnvironmentVariable("POSTGRES_DB_CONNECTION_STRING");

        if (!string.IsNullOrEmpty(connString))
            return connString;

        string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (args.Length > 0)
            env = args[0];

        IConfigurationRoot configuration = new ConfigurationBuilder()
                 .AddJsonFile($"appsettings.json", false)
                 .AddJsonFile($"appsettings.{env}.json", false)
                 .Build();

        Log.Logger.Information("Migration - No database configured via ENV parameters. Using one from 'appsettings.*.json'");

        connString = configuration.GetValue("DatabaseSettings:ConnectionString", "");

        if (string.IsNullOrEmpty(connString))
            throw new ArgumentNullException(nameof(args), "Conn string not set.");

        return connString;
    }
}
