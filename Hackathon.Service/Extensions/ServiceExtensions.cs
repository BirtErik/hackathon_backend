namespace Hackathon.Service.Extensions;

public static partial class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(p => p.AddPolicy("corsapp", builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));
    }

    public static void ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers();
    }
}
