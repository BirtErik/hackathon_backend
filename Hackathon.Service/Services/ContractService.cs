using Hackathon.Service.ApiResults;
using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.Services.Interfaces;

namespace Hackathon.Service.Services;

public class ContractService : IContractService
{
    private readonly IServiceRepository Repo;
    private readonly IReservationRequestService ReservationRequestService;
    private readonly IVenueService VenueService;

    public ContractService(IServiceRepository repo, IReservationRequestService reservationRequestService, IVenueService venueService)
    {
        Repo = repo;
        ReservationRequestService = reservationRequestService;
        VenueService = venueService;
    }

    public async Task<Guid> CreateContractFromReservationRequestAsync(Guid id)
    {
        ReservationRequestEntity reservationRequest = await ReservationRequestService.GetReservationRequestEntityByIdAsync(id);
        VenueResult venueResult = await VenueService.GetVenueByIdAsync(reservationRequest.VenueId);

        ContractEntity contractEntity = new ContractEntity
        {
            FirstName = reservationRequest.FirstName,
            LastName = reservationRequest.LastName,
            Address = reservationRequest.StreetAddress,
            Oib = reservationRequest.Oib,
            Place = reservationRequest.City,
            Deposit = venueResult.SecurityDeposit,
            Price = venueResult.Price,
            VenueName = venueResult.Name,
            VenueAddress = venueResult.Location.FullAddress,
            UserId = reservationRequest.UserId,
            VenueId = reservationRequest.VenueId,
            StartDate = reservationRequest.StartDate,
            EndDate = reservationRequest.EndDate,
            Bills = 0, // TODO: Add bills
            Status = "Initialized", // TODO: Define enum
            PostNumber = "0",
            Vat = 25,
        };

        await Repo.InsertAsync(contractEntity);
        await Repo.SaveChangesAsync();

        return contractEntity.Id;
    }
}
