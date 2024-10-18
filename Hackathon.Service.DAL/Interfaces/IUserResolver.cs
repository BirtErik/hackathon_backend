using Hackathon.Service.DAL.Models;

namespace Hackathon.Service.DAL.Interfaces;

public interface IUserResolver
{
    UserInfo? GetCurrentUserInfo();

    bool IsAdmin();

    Guid? GetTenantId();
}
