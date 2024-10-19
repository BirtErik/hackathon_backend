namespace Hackathon.Service.Models.Keycloak.Requests;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Enabled { get; set; }
    public UserCredential[]? Credentials { get; set; }
}
