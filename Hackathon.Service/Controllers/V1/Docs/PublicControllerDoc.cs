using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1.Docs;

public abstract class PublicControllerDoc : BaseController
{

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status409Conflict)]
    public abstract Task<ActionResult> CreateReservationRequest([FromBody] ReservationRequestCreateRequest request);

    [ProducesResponseType(typeof(ListTenantItemResult), StatusCodes.Status200OK)]
    public abstract Task<ActionResult<ListTenantItemResult>> ListAllTenantItems();

    
    [ProducesResponseType(typeof(ListVenueResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status404NotFound)]
    public abstract Task<ActionResult<ListVenueResult>> ListAllVenuesByTenantId(Guid id);


    [ProducesResponseType(typeof(VenueResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status404NotFound)]
    public abstract Task<ActionResult<VenueResult>> GetVenueByIdAsync(Guid id);


    [ProducesResponseType(typeof(ListVenueReservationResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    public abstract Task<ActionResult<ListVenueReservationResult>> GetVenueReservationsByVenueIdAsync(Guid id);


}
