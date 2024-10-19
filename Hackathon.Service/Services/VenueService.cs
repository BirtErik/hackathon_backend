using Hackathon.Service.ApiQueryParams;
using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiResults;
using Hackathon.Service.Common.Exceptions;
using Hackathon.Service.Converters;
using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Entities.Models;
using Hackathon.Service.DAL.Interfaces;
using Hackathon.Service.DAL.Models;
using Hackathon.Service.Models.Constants;
using Hackathon.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Service.Services;

public class VenueService : IVenueService
{
    private readonly IServiceRepository Repo;
    private readonly IUserService UserService;

    public VenueService(IServiceRepository repo, IUserService userService)
    {
        Repo = repo;
        UserService = userService;
    }

    public async Task<Guid> CreateAsync(VenueCreateRequest request)
    {
        UserInfo userInfo = Repo.GetUserInfo()!;

        VenueEntity venueEntity = new()
        {
            Name = request.Name!,
            Description = request.Description!,
            IsRentable = request.IsRentable,
            Location = new Location
            {
                Latitude = request.Location!.Latitude!,
                Longitude = request.Location!.Longitude!,
                FullAddress = request.Location!.FullAddress!,
            },
            Capacity = request.Capacity,
            Price = request.Price,
            SecurityDeposit = request.SecurityDeposit,
            TenantId = userInfo.TenantId!.Value,
            // TODO: Implement CreatedBy = Repo.GetCurrentUserInfo().UserId,
        };

        await Repo.InsertAsync(venueEntity);
        await Repo.SaveChangesAsync();

        return venueEntity.Id;
    }

    public async Task<ActionResult> CreateReservationRequestAsync(ReservationRequestCreateRequest request)
    {
        // Check if User with provided email exists
        Guid? userId = await UserService.GetUserIdByEmail(request.Email);

        // Check if provided Venue exists
        VenueEntity venueEntity = await GetVenueEntityByIdAsync(request.VenueId);

        if (userId != null)
        {
            // TODO: Check if there is already an reservation for provided date
            // TODO: Check does provided venueId exist, throw exception if doesn't

            ReservationRequestEntity reservationRequestEntity = new()
            {
                TenantId = venueEntity.TenantId,
                UserId = userId.Value,
                VenueId = request.VenueId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                City = request.City,
                StreetAddress = request.StreetAddress,
                Oib = request.Oib,
                Phone = request.Phone,
                BankName = request.BankName,
                Iban = request.Iban,
                Purpose = request.Purpose,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            await Repo.InsertAsync(reservationRequestEntity);
            await Repo.SaveChangesAsync();

            // TODO: Send email
            return new OkResult();
        }
        else
        {
            // Create user account, then create reservation and send email about login info
            // with initial password and reservation info
            var userInfo = new
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var newUserInfo = await UserService.CreateUserAsync(userInfo);

            ReservationRequestEntity reservationRequestEntity = new()
            {
                TenantId = venueEntity.TenantId,
                UserId = (Guid)newUserInfo.UserId,
                VenueId = request.VenueId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                City = request.City,
                StreetAddress = request.StreetAddress,
                Oib = request.Oib,
                Phone = request.Phone,
                BankName = request.BankName,
                Iban = request.Iban,
                Purpose = request.Purpose,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            await Repo.InsertAsync(reservationRequestEntity);
            await Repo.SaveChangesAsync();

            // TODO: Send email
            return new OkResult();
        }
    }

    public async Task UpdateAsync(Guid id, VenueUpdateRequest request)
    {
        VenueEntity? venueEntity = await GetVenueEntityByIdAsync(id);

        venueEntity.Name = request.Name!;
        venueEntity.Description = request.Description!;
        venueEntity.IsRentable = request.IsRentable;

        Repo.Update(venueEntity);
        await Repo.SaveChangesAsync();
    }

    public async Task<ListVenueResult> ListAllAsync(VenueQueryParams queryParams)
    {
        int take = (queryParams.Take <= 0 ? ApiConstants.Pagination.MaxPageSize : queryParams.Take);
        int skip = ((queryParams.Page < 1 ? 1 : queryParams.Page) - 1) * take;

        var venueQuery = Repo.AsQueryable<VenueEntity>()
                                .AsNoTracking();

        if (!string.IsNullOrEmpty(queryParams.Search))
        {
            string pattern = $"%{queryParams.Search}%";

            venueQuery = venueQuery
                .Where(x => EF.Functions.Like(x.Name, pattern) || EF.Functions.Like(x.Description, pattern));
        }

        int total = venueQuery.Count();

        venueQuery = venueQuery.Skip(skip).Take(take);

        List<ListVenueResultData> contents = (await venueQuery.ToListAsync()).Select(x => new ListVenueResultData
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            IsRentable = x.IsRentable,
            Location = x.Location,
        }).ToList();

        ListVenueResult result = new()
        {
            Data = contents,
            Total = total,
        };

        return result;
    }

    public async Task<ListReservationRequestResult> ListAllReservationRequests(ReservationRequestQueryParams queryParams)
    {
        int take = (queryParams.Take <= 0 ? ApiConstants.Pagination.MaxPageSize : queryParams.Take);
        int skip = ((queryParams.Page < 1 ? 1 : queryParams.Page) - 1) * take;

        var reservationRequest = Repo.AsQueryable<ReservationRequestEntity>()
                                .AsNoTracking();

        if (!string.IsNullOrEmpty(queryParams.Search))
        {
            string pattern = $"%{queryParams.Search}%";

            reservationRequest = reservationRequest
                .Where(x => EF.Functions.Like(x.FirstName, pattern) || EF.Functions.Like(x.LastName, pattern));
        }

        int total = reservationRequest.Count();

        reservationRequest = reservationRequest.Skip(skip).Take(take);

        List<ListReservationRequestResultData> contents = (await reservationRequest.ToListAsync()).Select(x => new ListReservationRequestResultData
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            StreetAddress = x.StreetAddress,
            City = x.City,
            Iban = x.Iban,
            BankName = x.BankName,
            Phone = x.Phone,
            Purpose = x.Purpose,
            Oib = x.Oib,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
        }).ToList();

        ListReservationRequestResult result = new()
        {
            Data = contents,
            Total = total,
        };

        return result;
    }

    public async Task<ListVenueResult> ListAllByTenanatIdAsync(Guid id)
    {
        var venueQuery = Repo.AsQueryable<VenueEntity>()
            .AsNoTracking();

        List<ListVenueResultData> contents = (await venueQuery.ToListAsync()).Select(x => new ListVenueResultData
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            IsRentable = x.IsRentable,
            Location = x.Location,
        }).ToList();

        int total = venueQuery.Count();

        ListVenueResult result = new()
        {
            Data = contents,
            Total = total,
        };

        return result;
    }

    public async Task<ListVenueItemResult> ListAllItemsAsync()
    {
        var venueQuery = Repo.AsQueryable<VenueEntity>().AsNoTracking();

        List<VenueEntity> venues = await venueQuery
            .OrderBy(x => x.Name)
            .ToListAsync();

        List<ListVenueItemResultData> venueItems = venues.Select(x => new ListVenueItemResultData
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();

        ListVenueItemResult result = new()
        {
            Data = venueItems,
        };

        return result;
    }

    public async Task<VenueResult> GetVenueByIdAsync(Guid id)
    {
        VenueEntity? venueEntity = await GetVenueEntityByIdAsync(id);

        if (venueEntity == null)
        {
            throw new NotFoundAxHttpException(
                errorCode: ApiErrorCodes.VENUE_RESOURCE_NOT_FOUND,
                errorMessage: $"Couldn't Get an Venue with id {id} because it doesn't exist.",
                moreInfo: "Please verify if the Venue resource exists and try again.");
        }
        else
            return venueEntity.ToResult();
    }

    public async Task<ListVenueReservationResult> GetVenueReservationsByVenueIdAsync(Guid id)
    {
        var venueReservationsQuery = Repo.AsQueryable<ContractEntity>()
            .Where(x => x.VenueId == id)
            .AsNoTracking();

        List<ContractEntity> venueReservations = await venueReservationsQuery.ToListAsync();

        List<ListVenueReservationResultData> venueReservationItems = venueReservations.Select(x => new ListVenueReservationResultData
        {
            StartDate = x.StartDate,
            EndDate = x.EndDate,
        }).ToList();

        ListVenueReservationResult result = new()
        {
            Data = venueReservationItems,
        };

        return result;
    }

    public async Task DeleteAsync(Guid id)
    {
        VenueEntity? venueEntity = await GetVenueEntityByIdAsync(id);

        Repo.Delete(venueEntity);

        await Repo.SaveChangesAsync();
    }

    private async Task<VenueEntity> GetVenueEntityByIdAsync(Guid id)
    {
        VenueEntity? venueEntity = await Repo.AsQueryable<VenueEntity>()
           .Where(x => x.Id == id)
           .FirstOrDefaultAsync();

        if (venueEntity == null)
        {
            throw new NotFoundAxHttpException(
                errorCode: ApiErrorCodes.VENUE_RESOURCE_NOT_FOUND,
                errorMessage: $"Couldn't Get an Venue with id {id} because it doesn't exist.",
                moreInfo: "Please verify if the Venue resource exists and try again.");
        }
        else
            return venueEntity;
    }
}
