using Hackathon.Service.ApiQueryParams;
using Hackathon.Service.ApiRequests;
using Hackathon.Service.ApiRequests.Models;
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
            TenantId = userInfo.TenantId!.Value,
            // TODO: Implement CreatedBy = Repo.GetCurrentUserInfo().UserId,
            Rooms = request.Rooms!.Select(x => new VenueRoomEntity
            {
                Name = x.Name!,
                Description = x.Description!,
                Capacity = (int)x.Capacity!,
                IsRentable = x.IsRentable

            }).ToList()
        };

        await Repo.InsertAsync(venueEntity);
        await Repo.SaveChangesAsync();

        return venueEntity.Id;
    }

    public async Task<ActionResult> CreateReservationAsync(VenueReservationCreateRequest request)
    {
        // Check if User with provided email exists
        Guid? userId = await UserService.GetUserIdByEmail(request.Email);

        if (userId != null)
        {
            // TODO: Check if there is already an reservation for provided date
            // TODO: Check does provided venueId exist, throw exception if doesn't

            // Create reservation for user and send email info about reservation
            VenueReservationEntity venueReservationEntity = new()
            {
                ContactEmail = request.Email,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                UserId = userId.Value,
                VenueId = request.VenueId
                // TODO: Add reservation items
            };

            await Repo.InsertAsync(venueReservationEntity);
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


            // TODO: Send email
            return new OkResult();
        }
    }

    public async Task UpdateAsync(Guid id, VenueUpdateRequest request)
    {
        VenueEntity? venueEntity = await GetVenueEntityByIdAsync(id);

        List<VenueRoomEntity> venueRoomEntities = new();

        if (request.Rooms != null)
        {
            venueRoomEntities = request.Rooms.Select(t => new VenueRoomEntity
            {
                Name = t.Name!,
                Description = t.Description!,
                Capacity = (int)t.Capacity!,
                IsRentable = t.IsRentable
            }).ToList();
        }

        venueEntity.Name = request.Name!;
        venueEntity.Description = request.Description!;
        venueEntity.IsRentable = request.IsRentable;
        venueEntity.Rooms = venueRoomEntities;

        Repo.Update(venueEntity);
        await Repo.SaveChangesAsync();
    }

    public async Task<ListVenueResult> ListAllAsync(VenueQueryParams queryParams)
    {
        int take = (queryParams.Take <= 0 ? ApiConstants.Pagination.MaxPageSize : queryParams.Take);
        int skip = ((queryParams.Page < 1 ? 1 : queryParams.Page) - 1) * take;

        var venueQuery = Repo.AsQueryable<VenueEntity>()
                                .Include(v => v.Rooms)
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
            Capacity = x.Rooms.Sum(y => y.Capacity),
            IsRentable = x.IsRentable,
            Location = x.Location,
            Rooms = x.Rooms.Select(y => new VenueRoom
            {
                Name = y.Name,
                Description = y.Description,
                Capacity = y.Capacity,
                IsRentable = y.IsRentable
            }).ToList()
        }).ToList();

        ListVenueResult result = new()
        {
            Data = contents,
            Total = total,
        };

        return result;
    }

    public async Task<ListVenueResult> ListAllByTenanatIdAsync(Guid id)
    {
        var venueQuery = Repo.AsQueryable<VenueEntity>()
            .Include(v => v.Rooms)
            .Where(x => x.TenantId == id)
            .AsNoTracking();

        List<ListVenueResultData> contents = (await venueQuery.ToListAsync()).Select(x => new ListVenueResultData
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Capacity = x.Rooms.Sum(y => y.Capacity),
            IsRentable = x.IsRentable,
            Location = x.Location,
            Rooms = x.Rooms.Select(y => new VenueRoom
            {
                Name = y.Name,
                Description = y.Description,
                Capacity = y.Capacity,
                IsRentable = y.IsRentable
            }).ToList()
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
        var venueReservationsQuery = Repo.AsQueryable<VenueReservationEntity>()
            .Where(x => x.VenueId == id)
            .AsNoTracking();

        List<VenueReservationEntity> venueReservations = await venueReservationsQuery.ToListAsync();

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
           .Include(x => x.Rooms)
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
