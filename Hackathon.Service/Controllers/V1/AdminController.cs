using FluentValidation;
using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Hackathon.Service.Common.Exceptions;
using Hackathon.Service.Controllers.V1.Docs;
using Hackathon.Service.Extensions;
using Hackathon.Service.Models.Constants;
using Hackathon.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1;

[Authorize(Roles = RoleNames.Admin)]
[ApiController]
[Route("api/v1/admin")]
public class AdminController : AdminControllerDoc
{
    private readonly IUserService UserService;
    private readonly ITenantService TenantService;
    private readonly IVenueService VenueService;

    public AdminController(IUserService userService, ITenantService tenantService, IVenueService venueService)
    {
        UserService = userService;
        TenantService = tenantService;
        VenueService = venueService;
    }

    /// <summary>
    /// Endpoint that creates Mayor
    /// </summary>
    /// <param name="request"></param>
    /// <param name="validator"></param>
    [HttpPost("mayor")]
    public async Task<IActionResult> CreateMayor([FromServices] IValidator<MayorCreateRequest> validator, [FromBody] MayorCreateRequest request)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        Guid id = await UserService.CreateMayorAsync(request);

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Endpoint that creates Supervisor
    /// </summary>
    /// <param name="request"></param>
    /// <param name="validator"></param>
    [HttpPost("supervisor")]
    public async Task<IActionResult> CreateSupervisor([FromServices] IValidator<SupervisorCreateRequest> validator, [FromBody] SupervisorCreateRequest request)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        Guid id = await UserService.CreateSupervisorAsync(request);

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Endpoint that creates Custodian
    /// </summary>
    /// <param name="request"></param>
    /// <param name="validator"></param>
    [HttpPost("custodian")]
    public async Task<IActionResult> CreateCustodian([FromServices] IValidator<CustodianCreateRequest> validator, [FromBody] CustodianCreateRequest request)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        Guid id = await UserService.CreateCustodianAsync(request);

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Endpoint that creates Tenant
    /// </summary>
    /// <param name="request"></param>
    /// <param name="validator"></param>
    [HttpPost("tenant")]
    public async Task<IActionResult> CreateTenant([FromServices] IValidator<TenantCreateRequest> validator, [FromBody] TenantCreateRequest request)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        Guid id = await TenantService.CreateTenantAsync(request);

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Endpoint that gets all Tenants
    /// </summary>
    [HttpGet("tenants/all")]
    public async Task<ActionResult<ListTenantItemResult>> ListAllTenantItems()
    {
        return await TenantService.ListAllItemsAsync();
    }

    /// <summary>
    /// Endpoint that gets all Venues
    /// </summary>
    [HttpGet("venues/all")]
    public async Task<ActionResult<ListVenueItemResult>> ListAllVenueItems()
    {
        return await VenueService.ListAllItemsAsync();
    }
}
