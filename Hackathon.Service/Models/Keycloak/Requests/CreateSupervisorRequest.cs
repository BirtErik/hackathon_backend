namespace Hackathon.Service.Models.Keycloak.Requests
{
    public class CreateSupervisorRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Enabled { get; set; }

        public UserAttributes? Attributes { get; set; }
    }
}
