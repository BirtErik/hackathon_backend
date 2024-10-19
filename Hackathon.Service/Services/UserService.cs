using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiRequests.Models;
using Hackathon.Service.Models.Keycloak.Requests;
using Hackathon.Service.Models.Keycloak.Results;
using Hackathon.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Hackathon.Service.Services;

public class UserService : IUserService
{
    private readonly IHttpClientFactory HttpClientFactory;
    private readonly IConfiguration Configuration;
    private readonly string KeycloakUrl;
    private readonly string KeycloakAdminClientId;
    private readonly string KeycloakClientSecret;

    public UserService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        HttpClientFactory = httpClientFactory;
        Configuration = configuration;
        KeycloakUrl = Configuration.GetValue<string>("Keycloak:Url")!;
        KeycloakAdminClientId = Configuration.GetValue<string>("Keycloak:AdminClientId")!;
        KeycloakClientSecret = Configuration.GetValue<string>("Keycloak:ClientSecret")!;
    }

    public async Task<Guid> CreateMayorAsync(MayorCreateRequest request)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var newUser = new
        {
            username = request.Email,
            email = request.Email,
            firstName = request.FirstName,
            lastName = request.LastName,
            enabled = true,
            attributes = new
            {
                tenantId = new[] { request.TenantId }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        // TODO: Handle 409 conflict and other exceptions
        var locationHeader = response.Headers.Location;
        var userId = locationHeader.Segments.Last(); // This will get the user ID

        // Set User password
        await SetUserPassword(userId, request.Password);

        // Assign Supervisor role to user
        await AssignRoleToUser(userId, "Mayor");

        return Guid.Parse(userId);
    }

    public async Task<Guid> CreateSupervisorAsync(SupervisorCreateRequest request)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var newUser = new
        {
            username = request.Email,
            email = request.Email,
            firstName = request.FirstName,
            lastName = request.LastName,
            enabled = true,
            attributes = new
            {
                tenantId = new[] { request.TenantId }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        // TODO: Handle 409 conflict and other exceptions
        var locationHeader = response.Headers.Location;
        var userId = locationHeader.Segments.Last(); // This will get the user ID

        // Set User password
        await SetUserPassword(userId, request.Password);

        // Assign Supervisor role to user
        await AssignRoleToUser(userId, "Supervisor");

        return Guid.Parse(userId);
    }

    public async Task<UserDataResult> CreateUserAsync(UserInfoRequest request)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var randomPassword = GenerateRandomPassword(6);

        var newUser = new
        {
            username = request.Email,
            email = request.Email,
            firstName = request.FirstName,
            lastName = request.LastName,
            enabled = true,
            credentials = new[]
                {
                new
                {
                    type = "password",
                    value = randomPassword,
                    temporary = true
                }
            },
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        var locationHeader = response.Headers.Location;
        var userId = locationHeader.Segments.Last(); // This will get the user ID

        var userData = new UserDataResult
        {
            UserId = Guid.Parse(userId),
            Username = request.Email,
            Email = request.Email,
            Password = randomPassword
        };

        return userData;
    }

    public async Task<Guid> CreateCustodianAsync(CustodianCreateRequest request)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var newUser = new
        {
            username = request.Email,
            email = request.Email,
            firstName = request.FirstName,
            lastName = request.LastName,
            enabled = true,
            attributes = new
            {
                venueId = request.VenueId
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{KeycloakUrl}/users", content);

        // TODO: Handle 409 conflict and other exceptions
        var locationHeader = response.Headers.Location;
        var userId = locationHeader.Segments.Last(); // This will get the user ID

        // Set User password
        await SetUserPassword(userId, request.Password);

        // Assign Custodian role to user
        await AssignRoleToUser(userId, "Custodian"); // TODO: Add enum

        return Guid.Parse(userId);
    }



    public async Task<string> GetKeycloakAccessToken()
    {
        var client = HttpClientFactory.CreateClient();

        var requestBody = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("client_id", KeycloakAdminClientId),
                new KeyValuePair<string, string>("client_secret", KeycloakClientSecret),
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
            });

        var response = await client.PostAsync("http://localhost:9080/realms/venues-management/protocol/openid-connect/token", requestBody);

        var content = await response.Content.ReadAsStringAsync();
        var tokenData = JsonSerializer.Deserialize<JsonElement>(content);

        return tokenData.GetProperty("access_token").GetString();
    }

    public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Step 1: Get Client ID for 'venues-management-client'
        var clientIdResponse = await client.GetAsync($"{KeycloakUrl}/clients?clientId=venues-management-client");

        var clients = JsonSerializer.Deserialize<List<KeycloakClient>>(await clientIdResponse.Content.ReadAsStringAsync());
        var venuesManagementClient = clients.FirstOrDefault();

        // Step 2: Get the 'Supervisor' role from the client
        var roleResponse = await client.GetAsync($"{KeycloakUrl}/clients/{venuesManagementClient.Id}/roles/{roleName}");

        var role = JsonSerializer.Deserialize<KeycloakRole>(await roleResponse.Content.ReadAsStringAsync());

        // Step 3: Assign the 'Supervisor' role to the user
        var roleAssignmentContent = new StringContent(JsonSerializer.Serialize(new[] { role }), Encoding.UTF8, "application/json");
        var assignRoleResponse = await client.PostAsync($"{KeycloakUrl}/users/{userId}/role-mappings/clients/{venuesManagementClient.Id}", roleAssignmentContent);

        // deserialize respose content
        var responseContent = await assignRoleResponse.Content.ReadAsStringAsync();

        // deserialize request message content
        var requestContent = await roleAssignmentContent.ReadAsStringAsync();
        var assignRoleRequest = JsonSerializer.Deserialize<List<KeycloakRole>>(requestContent);

        return new OkObjectResult(new { requestContent, responseContent });
    }

    public async Task<Guid?> GetUserIdByEmail(string email)
    {
        var token = await GetKeycloakAccessToken();
        var client = HttpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync($"{KeycloakUrl}/users?email={email}");

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<KeycloakUserResult[]>(responseData);

            if (users != null && users.Length > 0)
            {
                // Get the user ID from the first matching user
                Guid userId = users[0].Id;
                return userId;
            }
        }

        // Return null if no user is found
        return null;
    }

    private async Task SetUserPassword(string userId, string newPassword)
    {
        var client = HttpClientFactory.CreateClient();
        var token = await GetKeycloakAccessToken();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var passwordData = new
        {
            type = "password",
            value = newPassword,
            temporary = true // Set to true if you want the user to change it on the next login
        };

        var content = new StringContent(JsonSerializer.Serialize(passwordData), Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{KeycloakUrl}/users/{userId}/reset-password", content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to set user password: {errorContent}");
        }
    }

    private string GenerateRandomPassword(int length)
    {
        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
        var password = new char[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            var bytes = new byte[length];

            rng.GetBytes(bytes);

            for (int i = 0; i < length; i++)
            {
                password[i] = validChars[bytes[i] % validChars.Length];
            }
        }
        return new string(password);
    }
}
