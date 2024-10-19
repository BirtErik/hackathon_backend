namespace Hackathon.Service.Extensions;

public static partial class AppExtensions
{
    public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.EnableTryItOutByDefault();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Venues management API v1");
            });
        }
    }
}