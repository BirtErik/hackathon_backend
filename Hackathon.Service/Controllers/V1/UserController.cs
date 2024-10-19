using Hackathon.Service.Controllers.V1.Docs;
using Hackathon.Service.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1;

[Authorize(Roles = RoleNames.User)]
[ApiController]
[Route("api/v1/user")]
public class UserController : UserControllerDoc
{
}
