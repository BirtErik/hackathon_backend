using Hackathon.Service.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = RoleNames.Mayor)]
[ApiController]
[Route("api/v1/mayor")]
public class MayorController : MayorControllerDoc
{
}
