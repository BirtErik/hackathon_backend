namespace Hackathon.Service.Services.Interfaces;

public interface IContractService
{
    Task<Guid> CreateContractFromReservationRequestAsync(Guid id);
}
