using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Hackathon.Service.DAL.Core;

public class UserResolver : IUserResolver
{
    private readonly IHttpContextAccessor HttpContextAccessor;

    public UserResolver(IHttpContextAccessor httpContextAccessor)
    {
        HttpContextAccessor = httpContextAccessor!;
    }

    public UserInfo? GetCurrentUserInfo()
    {
        ClaimsPrincipal? user = HttpContextAccessor?.HttpContext?.User;

        if (user == null || !user.Identity!.IsAuthenticated)
        {
            return null;
        }

        List<string>? roles = HttpContextAccessor?.HttpContext?.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .Distinct()
            .ToList();

        string userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        Guid userId = new Guid(HttpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        // get tenantId from token
        Guid? tenantId = HttpContextAccessor?.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == "tenantId") != null
            ? Guid.Parse(HttpContextAccessor?.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == "tenantId")?.Value)
            : (Guid?)null;

        Guid? venueId = HttpContextAccessor?.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == "venueId") != null
            ? Guid.Parse(HttpContextAccessor?.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == "venueId")?.Value)
            : (Guid?)null;

        return new UserInfo
        {
            UserId = userId,
            TenantId = tenantId,
            VenueId = venueId,
            Roles = roles
        };
    }

    public bool IsAdmin()
    {
        var roles = GetCurrentUserInfo()?.Roles;
        return roles != null && roles.Contains("Admin");
    }

    public Guid? GetTenantId()
    {
        var tenantIdClaim = HttpContextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == "tenantId");

        return tenantIdClaim != null ? Guid.Parse(tenantIdClaim.Value) : (Guid?)null;
    }
}
