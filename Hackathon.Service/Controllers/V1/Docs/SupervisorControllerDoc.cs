using FluentValidation;
using Hackathon.Service.ApiQueryParams;
using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1.Docs;

public abstract class SupervisorControllerDoc : BaseController
{
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> CreateCustodian([FromServices] IValidator<CustodianCreateRequest> validator, [FromBody] CustodianCreateRequest request);

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> Create([FromServices] IValidator<VenueCreateRequest> validator, [FromBody] VenueCreateRequest request);

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> Update([FromServices] IValidator<VenueUpdateRequest> validator, Guid id, [FromBody] VenueUpdateRequest request);

    [ProducesResponseType(typeof(ListVenueResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    public abstract Task<ActionResult<ListVenueResult>> ListAll([FromServices] IValidator<BaseQueryParams> validator, [FromQuery] VenueQueryParams queryParams);

    [ProducesResponseType(typeof(VenueResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    public abstract Task<ActionResult<VenueResult>> GetVenueByIdAsync(Guid id);

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status404NotFound)]
    public abstract Task<ActionResult> Delete(Guid id);
}
