namespace Hackathon.Service.Models.Keycloak
{
    public class UserCredential
    {
        public string Type { get; set; }  // Credential type (e.g., password)
        public string Value { get; set; } // The credential value (e.g., password)
        public bool Temporary { get; set; } // Whether the credential is temporary
    }
}
