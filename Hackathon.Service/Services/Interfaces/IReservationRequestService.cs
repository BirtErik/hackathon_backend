using Hackathon.Service.DAL.Entities;

namespace Hackathon.Service.Services.Interfaces;

public interface IReservationRequestService
{
    Task<ReservationRequestEntity> GetReservationRequestEntityByIdAsync(Guid id);
}
