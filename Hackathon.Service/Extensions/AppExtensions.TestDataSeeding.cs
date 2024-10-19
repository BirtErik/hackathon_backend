using Hackathon.Service.DAL.DataSeeding.TestData;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Service.Extensions;

public static partial class AppExtensions
{
    public static void TestDataSeeding(this IApplicationBuilder app, string connString)
    {
        DbContextOptionsBuilder<TestDataSeedingContext> optionsBuilder = new DbContextOptionsBuilder<TestDataSeedingContext>();
        optionsBuilder.UseNpgsql(connString);

        using TestDataSeedingContext context = new TestDataSeedingContext(optionsBuilder.Options, connString);
        context.Database.EnsureCreated();
        context.SaveChanges();
    }
}
