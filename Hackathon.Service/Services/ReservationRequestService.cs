using Hackathon.Service.Common.Exceptions;
using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Service.Services;

public class ReservationRequestService : IReservationRequestService
{
    private readonly IServiceRepository Repo;

    public ReservationRequestService(IServiceRepository repo)
    {
        Repo = repo;
    }

    public async Task<ReservationRequestEntity> GetReservationRequestEntityByIdAsync(Guid id)
    {
        ReservationRequestEntity? reservationRequestEntity = await Repo.AsQueryable<ReservationRequestEntity>()
           .Where(x => x.Id == id)
           .FirstOrDefaultAsync();

        if (reservationRequestEntity == null)
        {
            throw new NotFoundAxHttpException(
                errorCode: ApiErrorCodes.VENUE_RESOURCE_NOT_FOUND,
                errorMessage: $"Couldn't Get an Reservation Request with id {id} because it doesn't exist.",
                moreInfo: "Please verify if the Reservation Request resource exists and try again.");
        }
        else
            return reservationRequestEntity;
    }
}