using FluentValidation;
using FluentValidation.AspNetCore;

namespace Hackathon.Service.Extensions;

public static partial class ServiceExtensions
{
    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblyContaining<Startup>();
    }
}
