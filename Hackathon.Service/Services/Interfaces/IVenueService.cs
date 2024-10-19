using Hackathon.Service.ApiQueryParams;
using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Service.Services.Interfaces;

public interface IVenueService
{
    Task<Guid> CreateAsync(VenueCreateRequest request);

    Task<ActionResult> CreateReservationRequestAsync(ReservationRequestCreateRequest request);

    Task UpdateAsync(Guid id, VenueUpdateRequest request);

    Task<ListVenueResult> ListAllAsync(VenueQueryParams queryParams);

    Task<ListVenueResult> ListAllByTenanatIdAsync(Guid id);

    Task<ListVenueItemResult> ListAllItemsAsync();

    Task<ListReservationRequestResult> ListAllReservationRequests(ReservationRequestQueryParams queryParams);

    Task<VenueResult> GetVenueByIdAsync(Guid id);

    Task<ListVenueReservationResult> GetVenueReservationsByVenueIdAsync(Guid id);

    Task DeleteAsync(Guid id);
}
