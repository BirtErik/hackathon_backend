﻿using Hackathon.Service.ApiRequests.Models;
using Hackathon.Service.ApiResults;
using Hackathon.Service.DAL.Entities;

namespace Hackathon.Service.Converters;

public static class EntityToResult
{
    public static VenueResult ToResult(this VenueEntity venueEntity)
    {
        return new VenueResult
        {
            Id = venueEntity.Id,
            Name = venueEntity.Name,
            Description = venueEntity.Description,
            IsRentable = venueEntity.IsRentable,
            Location = venueEntity.Location,     
        };
    }
}
