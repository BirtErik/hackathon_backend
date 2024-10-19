using Hackathon.Service.ApiResults;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1.Docs;

public abstract class PublicControllerDoc : BaseController
{
    [ProducesResponseType(typeof(VenueResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    public abstract Task<ActionResult<VenueResult>> GetVenueByIdAsync(Guid id);

    [ProducesResponseType(typeof(VenueResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetailsResult), StatusCodes.Status400BadRequest)]
    public abstract Task<ActionResult<ListVenueReservationResult>> GetVenueReservationsByVenueIdAsync(Guid id);
}
