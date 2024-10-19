using Hackathon.Service.DAL.DataSeeding.TestData;
using Hackathon.Service.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Hackathon.Service.Services;

public class UserSeedService : IUserSeedService
{
    private readonly TestDataSeedingContext TestDataSeedingContext;
    private readonly IUserService UserService;
    private readonly IHttpClientFactory HttpClientFactory;
    private readonly IConfiguration Configuration;
    private readonly string KeycloakUrl;

    public UserSeedService(TestDataSeedingContext context, IUserService userService, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        TestDataSeedingContext = context;
        UserService = userService;
        HttpClientFactory = httpClientFactory;
        Configuration = configuration;
        KeycloakUrl = Configuration.GetValue<string>("Keycloak:Url")!;
    }

    public async Task SeedUsersAsync()
    {
        // Get inserted tenant and venue IDs
        Guid tenant1Id = TestDataSeedingContext.Tenant1Id;
        Guid tenant2Id = TestDataSeedingContext.Tenant2Id;
        Guid venue1Id = TestDataSeedingContext.Venue1Id;
        Guid venue2Id = TestDataSeedingContext.Venue2Id;

        // Create Admin
        try
        {
            await CreateAdminAsync(
                new
                {
                    Username = "admin",
                    Email = "admin@admin.com",
                    Password = "admin",
                    FirstName = "Admin",
                    LastName = "Admin"
                });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Create Mayor
        try
        {
            dynamic mayor = new
            {
                Username = "mayor",
                Email = "mayor@vm.com",
                Password = "mayor",
                FirstName = "Dario",
                LastName = "Hrebak",
                TenantId = TestDataSeedingContext.Tenant1Id
            };
            await CreateMayor(mayor);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Create Supervisors
        try
        {
            await CreateSupervisors();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Create Custodians
        try
        {
            await CreateCustodians();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private async Task CreateSupervisors()
    {
        var supervisors = new[]
        {
            new
            {
                Username = "supervisor1",
                Email = "supervisor1@vm.com",
                Password = "supervisor1",
                FirstName = "Supervisor1",
                LastName = "Supervisor2",
                TenantId = TestDataSeedingContext.Tenant1Id
            },
            new
            {
                Username = "supervisor2",
                Email = "supervisor2@vm.com",
                Password = "supervisor2",
                FirstName = "Supervisor2",
                LastName = "Supervisor2",
                TenantId = TestDataSeedingContext.Tenant2Id
            }
        };

        foreach (var supervisor in supervisors)
        {
            await CreateSupervisor(supervisor);
        }
    }

    private async Task CreateCustodians()
    {
        var custodians = new[]
        {
            new
            {
                Username = "custodian1",
                Email = "custodian1@vm.com",
                Password = "custodian1",
                FirstName = "Custodian",
                LastName = "Venues",
                VenueId = TestDataSeedingContext.Venue1Id
                },
            new
            {
                Username = "custodian2",
                Email = "custodian2@vm.com",
                Password = "custodian2",
                FirstName = "Custodian",
                LastName = "Venues",
                VenueId = TestDataSeedingContext.Venue2Id
            }
        };

        foreach (var custodian in custodians)
        {
            await CreateCustodian(custodian);
        }
    }

    private async Task CreateMayor(dynamic mayor)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await UserService.GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var newUser = new
        {
            username = mayor.Username,
            email = mayor.Email,
            firstName = mayor.FirstName,
            lastName = mayor.LastName,
            enabled = true,
            attributes = new
            {
                tenantId = new[] { mayor.TenantId }
            },
            credentials = new[]
            {
                new
                {
                    type = "password",
                    value = mayor.Password,
                    temporary = false
                }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        // TODO: Handle 409 conflict and other exceptions
        var locationHeader = response.Headers.Location;

        if (locationHeader == null)
        {
            return;
        }

        var userId = locationHeader.Segments.Last(); // This will get the user ID

        // Assign Supervisor role to user
        await UserService.AssignRoleToUser(userId, "Mayor"); // TODO: Add enum
    }

    private async Task CreateSupervisor(dynamic supervisor)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await UserService.GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var newUser = new
        {
            username = supervisor.Username,
            email = supervisor.Email,
            firstName = supervisor.FirstName,
            lastName = supervisor.LastName,
            enabled = true,
            attributes = new
            {
                tenantId = new[] { supervisor.TenantId }
            },
            credentials = new[]
            {
                new
                {
                    type = "password",
                    value = supervisor.Password,
                    temporary = false
                }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        // TODO: Handle 409 conflict and other exceptions
        var locationHeader = response.Headers.Location;

        if (locationHeader == null)
        {
            return;
        }

        var userId = locationHeader.Segments.Last(); // This will get the user ID

        // Assign Supervisor role to user
        await UserService.AssignRoleToUser(userId, "Supervisor"); // TODO: Add enum
    }

    private async Task CreateCustodian(dynamic custodian)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await UserService.GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var newUser = new
        {
            username = custodian.Username,
            email = custodian.Email,
            firstName = custodian.FirstName,
            lastName = custodian.LastName,
            enabled = true,
            attributes = new
            {
                venueId = new[] { custodian.VenueId }
            },
            credentials = new[]
            {
                new
                {
                    type = "password",
                    value = custodian.Password,
                    temporary = false
                }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        // TODO: Handle 409 conflict and other exceptions
        var locationHeader = response.Headers.Location;

        if (locationHeader == null)
        {
            return;
        }

        var userId = locationHeader.Segments.Last(); // This will get the user ID

        // Assign Custodian role to user
        await UserService.AssignRoleToUser(userId, "Custodian");
    }

    private async Task CreateAdminAsync(dynamic request)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await UserService.GetKeycloakAccessToken(); // Retrieve SuperAdmin access token

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var newUser = new
        {
            username = request.Username,
            email = request.Email,
            firstName = request.FirstName,
            lastName = request.LastName,
            enabled = true,
            credentials = new[]
            {
                new
                {
                    type = "password",
                    value = request.Password,
                    temporary = false
                }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        // TODO: Handle 409 conflict and other exceptions
        var locationHeader = response.Headers.Location;

        if (locationHeader == null)
        {
            return;
        }

        var userId = locationHeader.Segments.Last(); // This will get the user ID

        // Assign Admin role to user
        await UserService.AssignRoleToUser(userId, "Admin");
    }
}
