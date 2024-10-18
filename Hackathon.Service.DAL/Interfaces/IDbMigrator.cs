using Hackathon.Service.DAL.DbContexts;

namespace Hackathon.Service.DAL.Interfaces;

public interface IDbMigrator
{
    ServiceDbContext CreateDbContext();

    void Migrate(string connString);
}