using Hackathon.Service.DAL.DataSeeding.TestData;
using Hackathon.Service.DAL.DbContexts;
using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Service.Extensions;

public static partial class ServiceExtensions
{
    public static void ConfigureDal(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ServiceDbContext>(o =>
        {
            o.UseNpgsql(connectionString, options => options.MigrationsAssembly(typeof(ServiceDbContext).Assembly.FullName));
        });

        services.AddDbContext<TestDataSeedingContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IServiceRepository, ServiceRepository>();
    }
}
