using Hackathon.Service.DAL.DbContexts;
using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Service.DAL.DataSeeding.TestData;

public class TestDataSeedingContext : BaseDbContext<TestDataSeedingContext>
{
    public readonly Guid Tenant1Id = Guid.Parse("31ee5349-61bf-43b4-a490-07a42b12cca9");
    public readonly Guid Tenant2Id = Guid.Parse("4b0cdd33-a4c1-4958-897e-ef9b332531a6");
    public readonly Guid Venue1Id = Guid.Parse("4cd88e07-8b55-4375-9162-2a2b63ac8f90");
    public readonly Guid Venue2Id = Guid.Parse("bdf53f04-2b4c-458a-9a70-24e0cd3ec44e");

    public TestDataSeedingContext(DbContextOptions<TestDataSeedingContext> options)
        : base(options)
    {
    }

    public TestDataSeedingContext(DbContextOptions<TestDataSeedingContext> options, string connString)
        : base(options)
    {
        Database.SetConnectionString(connString);
        SeedDataAsync().GetAwaiter().GetResult();
    }

    public async Task SeedDataAsync()
    {
        if (!Tenants.Any())
        {
            Tenants.Add(new TenantEntity
            {
                Id = Tenant1Id,
                Name = "Grad Bjelovar",
                Description = "Tenant za upravljanje domovima u Bjelovaru.",
                Venues = new[] {
                    new VenueEntity
                    {
                        Id = Venue1Id,
                        Name = "Mjesni dom Pulman",
                        Description = "Ribopecačko namjenjen dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Trg Eugena Kvaternika 1, 43000, Bjelovar, Croatia",
                            Latitude = 45.9028,
                            Longitude = 16.8481
                        },
                        TenantId = Tenant1Id,
                        Rooms = new[] {
                            new VenueRoomEntity
                            {
                                Id = Guid.NewGuid(),
                                Name = "Sala",
                                Description = "Unutarnji smjestaj.",
                                Capacity = 200,
                                IsRentable = true
                            },
                            new VenueRoomEntity
                            {
                                Id = Guid.NewGuid(),
                                Name = "Terasa",
                                Description = "Vanjska natkrivena terasa.",
                                IsRentable = true,
                                Capacity = 100
                            }
                        }
                    }
                }
            });

            Tenants.Add(new TenantEntity
            {
                Id = Tenant2Id,
                Name = "Grad Zagreb",
                Description = "Tenant za upravljanje domovima u Zagrebu.",
                Venues = new[] {
                    new VenueEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Arena Zagreb",
                        Description = "Najveća arena u Zagrebu.",
                         IsRentable = true,
                         Location = new Location
                         {
                             FullAddress = "Trg Krešimira Ćosića 11, 10000, Zagreb, Croatia",
                             Latitude = 45.8075,
                             Longitude = 15.9871
                         },
                         TenantId = Tenant2Id,
                         Rooms = new[] {
                             new VenueRoomEntity
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Dvorana 1",
                                    Description = "Dvorana za konferencije.",
                                    Capacity = 200,
                                    IsRentable = true
                                },
                                new VenueRoomEntity
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Dvorana 2",
                                    Description = "Dvorana za sportske događaje.",
                                    IsRentable = false,
                                    Capacity = 20000
                                }
                            }
                    }
                }
            });

            await SaveChangesAsync();
        }
    }
}