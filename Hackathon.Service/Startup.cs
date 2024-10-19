using Hackathon.Service.Common;
using Hackathon.Service.Extensions;
using Hackathon.Service.Models.Constants;
using Hackathon.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Hackathon.Service;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressInferBindingSourcesForParameters = true;
        });
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Authority = "http://localhost:9080/realms/venues-management";
            options.RequireHttpsMetadata = false;   // TODO: Use true for production (requires HTTPS), load from env
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "http://localhost:8080/auth/realms/venues-management",
                ValidateAudience = true,
                ValidAudiences = new[] { "venues-management-client", "account" }, // Multiple audiences
                ValidateLifetime = true,
            };
            // Modify default way of reading roles
            // TODO: Try implement this cleaner
            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;

                    if (claimsIdentity != null)
                    {
                        // Extract the 'resource_access' claim
                        var resourceAccessClaim = context.Principal.Claims
                            .FirstOrDefault(c => c.Type == "resource_access")?.Value;

                        if (!string.IsNullOrEmpty(resourceAccessClaim))
                        {
                            // Parse the resource_access claim
                            var resourceAccessObj = JsonDocument.Parse(resourceAccessClaim);

                            // Navigate to the specific client to get roles
                            if (resourceAccessObj.RootElement.TryGetProperty("venues-management-client", out var clientInfo))
                            {
                                if (clientInfo.TryGetProperty("roles", out var rolesArray))
                                {
                                    foreach (var role in rolesArray.EnumerateArray())
                                    {
                                        // Add each role to the claims identity using ClaimTypes.Role
                                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.GetString()!));
                                    }
                                }
                            }
                        }
                    }

                    return Task.CompletedTask;
                }
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy => policy.RequireRole(RoleNames.Admin));
            options.AddPolicy("SupervisorPolicy", policy => policy.RequireRole(RoleNames.Supervisor));
            options.AddPolicy("CustodianPolicy", policy => policy.RequireRole(RoleNames.Custodian));
            options.AddPolicy("UserPolicy", policy => policy.RequireRole(RoleNames.User));
        });

        string dbConnString = ConfigurationUtils.GetDbConnectionString(Configuration);

        services.AddHttpClient();
        services.ConfigureCommon(dbConnString, false);
        services.ConfigureFluentValidation();
        //services.ConfigureJsonOptions();
        services.AddControllers();
        services.ConfigureSwagger(Configuration);
        services.ConfigureDal(dbConnString);
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
        });
        services.ConfigureNpgDbMigrator();
        services.ConfigureUserResolver();
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<Microsoft.AspNetCore.ResponseCompression.GzipCompressionProvider>();
        });
        //services.ConfigureOptions(Configuration);
        services.ConfigureCors();
        services.AddRouting(co =>
        {
            co.LowercaseUrls = true;
        });
        services.AddLocalization(o => o.ResourcesPath = "Resources");
        services.AddWebEncoders();
        services.Configure<Microsoft.AspNetCore.ResponseCompression.GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Fastest);
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<Microsoft.AspNetCore.ResponseCompression.GzipCompressionProvider>();
        });
        services.AddServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
    {
        ForwardedHeadersOptions options = new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        };
        options.KnownNetworks.Clear();
        options.KnownProxies.Clear();

        app.UseForwardedHeaders(options);

        app.UseNpgDbMigrator(ConfigurationUtils.GetDbConnectionString(Configuration));

        app.UseGlobalExceptionHandler();

        if (!env.IsProduction())
        {
            app.UseCors(c => c
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
                .WithExposedHeaders(HeaderNames.ContentDisposition));

            app.UseSwagger(Configuration, env);
        }

        if (!env.IsProduction())
        {
            app.TestDataSeeding(ConfigurationUtils.GetDbConnectionString(Configuration));
        }

        if (!env.IsProduction())
        {
            using (var scope = services.CreateScope())
            {
                var seedService = scope.ServiceProvider.GetRequiredService<IUserSeedService>();
                seedService.SeedUsersAsync().GetAwaiter().GetResult();
            }
        }

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();
        });
    }
}