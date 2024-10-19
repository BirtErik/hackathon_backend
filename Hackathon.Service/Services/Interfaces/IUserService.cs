using Hackathon.Service.ApiRequests;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Services.Interfaces;

public interface IUserService
{
    Task<Guid> CreateMayorAsync(MayorCreateRequest request);

    Task<Guid> CreateSupervisorAsync(SupervisorCreateRequest request);

    Task<Guid> CreateCustodianAsync(CustodianCreateRequest request);

    Task<dynamic> CreateUserAsync(dynamic request);

    Task<string> GetKeycloakAccessToken();

    Task<IActionResult> AssignRoleToUser(string userId, string roleName);

    Task<Guid?> GetUserIdByEmail(string email);
}
