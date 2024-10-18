namespace Hackathon.Service.DAL.Models;

public class UserInfo
{
    public Guid UserId { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? VenueId { get; set; }

    public List<string>? Roles { get; set; }
}
