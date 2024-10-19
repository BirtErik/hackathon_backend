using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Hackathon.Service.Controllers.V1.Docs;
using Hackathon.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Controllers.V1;

[AllowAnonymous]
[ApiController]
[Route("api/v1/public")]
public class PublicController : PublicControllerDoc
{
    private readonly ITenantService TenantService;
    private readonly IVenueService VenueService;

    public PublicController(ITenantService tenantService, IVenueService venueService)
    {
        TenantService = tenantService;
        VenueService = venueService;
    }

    /// <summary>
    /// Endpoint that creates a Reservation Request
    /// </summary>
    [HttpPost("reservation-requests")]
    public async Task<ActionResult> CreateReservationRequest([FromBody] ReservationRequestCreateRequest request)
    {
        return await VenueService.CreateReservationRequestAsync(request);
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
    /// Endpoint that gets all Venues by TenantId
    /// </summary>
    [HttpGet("tenants/{id:guid}/venues")]
    public async Task<ActionResult<ListVenueResult>> ListAllVenuesByTenantId(Guid id)
    {
        return await VenueService.ListAllByTenanatIdAsync(id);
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
    /// Endpoint that gets Venue Reservations by VenueId
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("venues/{id:guid}/reservations")]
    public override async Task<ActionResult<ListVenueReservationResult>> GetVenueReservationsByVenueIdAsync(Guid id)
    {
        return await VenueService.GetVenueReservationsByVenueIdAsync(id);
    }
}
