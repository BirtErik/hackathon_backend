using Hackathon.Service.Controllers.V1.Docs;
using Hackathon.Service.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1;

[Authorize(Roles = RoleNames.Custodian)]
[ApiController]
[Route("api/v1/custodian")]
public class CustodianController : CustodianControllerDoc
{
}
