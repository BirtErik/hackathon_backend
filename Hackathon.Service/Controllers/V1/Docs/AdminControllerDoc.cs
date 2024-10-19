using FluentValidation;
using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1.Docs;

public abstract class AdminControllerDoc : BaseController
{
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> CreateMayor([FromServices] IValidator<MayorCreateRequest> validator, [FromBody] MayorCreateRequest request);

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> CreateSupervisor([FromServices] IValidator<SupervisorCreateRequest> validator, [FromBody] SupervisorCreateRequest request);

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> CreateCustodian([FromServices] IValidator<CustodianCreateRequest> validator, [FromBody] CustodianCreateRequest request);

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> CreateTenant([FromServices] IValidator<TenantCreateRequest> validator, [FromBody] TenantCreateRequest request);


    [ProducesResponseType(typeof(ListTenantItemResult), StatusCodes.Status200OK)]
    public abstract Task<ActionResult<ListTenantItemResult>> ListAllTenantItems();


    [ProducesResponseType(typeof(ListVenueItemResult), StatusCodes.Status200OK)]
    public abstract Task<ActionResult<ListVenueItemResult>> ListAllVenueItems();

}
