﻿namespace Hackathon.Service.ApiRequests;

public class SupervisorCreateRequest
{
    public string Email { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Guid TenantId { get; set; }
}
