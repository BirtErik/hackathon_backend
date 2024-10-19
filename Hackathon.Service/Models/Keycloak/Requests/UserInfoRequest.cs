namespace Hackathon.Service.Models.Keycloak.Requests;

public class UserInfoRequest
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
