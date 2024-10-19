namespace Hackathon.Service.Models.Keycloak.Results;

public class UserDataResult
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
