using FluentValidation;
using Hackathon.Service.ApiQueryParams;
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

[Authorize(Roles = RoleNames.Supervisor)]
[ApiController]
[Route("api/v1/supervisor")]
public class SupervisorController : SupervisorControllerDoc
{
    private readonly IUserService UserService;
    private readonly IVenueService VenueService;

    public SupervisorController(IUserService userService, IVenueService venueService)
    {
        UserService = userService;
        VenueService = venueService;
    }

    /// <summary>
    /// Endpoint that creates Custodian
    /// </summary>
    /// <param name="request"></param>
    /// <param name="validator"></param>
    [HttpPost("custodian")]
    public override async Task<ActionResult> CreateCustodian([FromServices] IValidator<CustodianCreateRequest> validator, [FromBody] CustodianCreateRequest request)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        Guid id = await UserService.CreateCustodianAsync(request);

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Endpoint that gets all Venues for Supervisor's tenantId
    /// </summary>
    [HttpGet("venues/all")]
    public override async Task<ActionResult<ListVenueItemResult>> ListAllVenueItems()
    {
        return await VenueService.ListAllItemsAsync();
    }

    /// <summary>
    /// Endpoint that creates Venue
    /// </summary>
    /// <param name="request"></param>
    /// <param name="validator"></param>
    [HttpPost("venues")]
    public override async Task<ActionResult> Create([FromServices] IValidator<VenueCreateRequest> validator, [FromBody] VenueCreateRequest request)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        Guid id = await VenueService.CreateAsync(request);

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Endpoint that updates Venue
    /// </summary>
    /// <param name="request"></param>
    /// <param name="id"></param>
    /// <param name="validator"></param>
    [HttpPut("venues/{id:guid}")]
    public override async Task<ActionResult> Update([FromServices] IValidator<VenueUpdateRequest> validator, Guid id, [FromBody] VenueUpdateRequest request)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        await VenueService.UpdateAsync(id, request);

        return NoContent();
    }

    /// <summary>
    /// Endpoint that gets Venues
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="validator"></param>
    [HttpGet("venues")]
    public override async Task<ActionResult<ListVenueResult>> ListAll([FromServices] IValidator<BaseQueryParams> validator, [FromQuery] VenueQueryParams queryParams)
    {
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(queryParams);
        if (!validationResult.IsValid)
            throw new BadRequestAxHttpException(moreInfo: validationResult.Errors.ToSimpleMessageString());

        return await VenueService.ListAllAsync(queryParams);
    }

    /// <summary>
    /// Endpoint that gets Venue by Id
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("venues/{id:guid}")]
    public override async Task<ActionResult<VenueResult>> GetVenueByIdAsync(Guid id)
    {
        return await VenueService.GetVenueByIdAsync(id);
    }

    /// <summary>
    /// Endpoint that deletes Venue
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("venues/{id:guid}")]
    public override async Task<ActionResult> Delete(Guid id)
    {
        await VenueService.DeleteAsync(id);

        return NoContent();
    }
}
