using Hackathon.Service.DAL.DbContexts;
using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Hackathon.Service.DAL.DataSeeding.TestData;

public class TestDataSeedingContext : BaseDbContext<TestDataSeedingContext>
{
    public readonly Guid Tenant1Id = Guid.Parse("31ee5349-61bf-43b4-a490-07a42b12cca9");
    public readonly Guid Tenant2Id = Guid.Parse("4b0cdd33-a4c1-4958-897e-ef9b332531a6");
    public readonly Guid Venue1Id = Guid.Parse("4cd88e07-8b55-4375-9162-2a2b63ac8f90");
    public readonly Guid Venue2Id = Guid.Parse("bdf53f04-2b4c-458a-9a70-24e0cd3ec44e");
    public readonly Guid Venue3Id = Guid.NewGuid();
    public readonly Guid Venue4Id = Guid.NewGuid();
    public readonly Guid Venue5Id = Guid.NewGuid();
    public readonly Guid Venue6Id = Guid.NewGuid();
    public readonly Guid Venue7Id = Guid.NewGuid();
    public readonly Guid Venue8Id = Guid.NewGuid();
    public readonly Guid Venue9Id = Guid.NewGuid();
    public readonly Guid Venue10Id = Guid.NewGuid();
    public readonly Guid Venue11Id = Guid.NewGuid();
    public readonly Guid Venue12Id = Guid.NewGuid();
    public readonly Guid Venue13Id = Guid.NewGuid();
    public readonly Guid Venue14Id = Guid.NewGuid();
    public readonly Guid Venue15Id = Guid.NewGuid();
    public readonly Guid Venue16Id = Guid.NewGuid();
    public readonly Guid Venue17Id = Guid.NewGuid();
    public readonly Guid Venue18Id = Guid.NewGuid();
    public readonly Guid Venue19Id = Guid.NewGuid();
    public readonly Guid Venue20Id = Guid.NewGuid();
    public readonly Guid Venue21Id = Guid.NewGuid();
    public readonly Guid Venue22Id = Guid.NewGuid();
    public readonly Guid Venue23Id = Guid.NewGuid();
    public readonly Guid Venue24Id = Guid.NewGuid();
    public readonly Guid Venue25Id = Guid.NewGuid();
    public readonly Guid Venue26Id = Guid.NewGuid();
    public readonly Guid Venue27Id = Guid.NewGuid();
    public readonly Guid Venue28Id = Guid.NewGuid();
    public readonly Guid Venue29Id = Guid.NewGuid();
    public readonly Guid Venue30Id = Guid.NewGuid();
    public readonly Guid Venue31Id = Guid.NewGuid();
    public readonly Guid Venue32Id = Guid.NewGuid();

    public readonly Guid Venue99Id = Guid.NewGuid();


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
                        Name = "Mjesni dom A. G. Matoš",
                        Description = "Koriste udruge.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Janka Draškovića 8/1, 43000, Bjelovar, Croatia",
                            Latitude = 45.894400777503115,
                            Longitude = 16.841388496733092
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue2Id,
                        Name = "Mjesni dom Dr. Ante Starčević",
                        Description = "Mjesni dom za iznajmljivanje.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Ulica Alojzija Stepinca 20a, 43000, Bjelovar, Croatia",
                            Latitude = 45.90704140825666,
                            Longitude = 16.844389305123684
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue3Id,
                        Name = "Mjesni dom Zvijerci",
                        Description = "Koristi svećenik.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Zvijerci 77a, 43000, Bjelovar, Croatia",
                            Latitude = 45.92368733425094, 
                            Longitude = 16.86435901207815
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue4Id,
                        Name = "Mjesni dom Stjepana Radića",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Ul. Andrije Mohorovičića 59, 43000, Bjelovar, Croatia",
                            Latitude = 45.898849202393706,
                            Longitude = 16.83117753885558
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue5Id,
                        Name = "Mjesni dom Križevačka cesta",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Križevačka cesta 3a, 43000, Bjelovar, Croatia",
                            Latitude = 45.9066031655313, 
                            Longitude = 16.82249707783893
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue6Id,
                        Name = "Mjesni dom Hrgovljani",
                        Description = "Najači dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Miroslava Krleže 187, 43000, Bjelovar, Croatia",
                            Latitude = 45.92143805766955, 
                            Longitude = 16.824765040913793
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue7Id,
                        Name = "Mjesni dom Ban J. Jelačić",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Radničko naselje prilaz II, 43000, Bjelovar, Croatia",
                            Latitude = 45.891449253459726, 
                            Longitude = 16.860769922645908
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue8Id,
                        Name = "Mjesni dom Kneza Domagoja",
                        Description = "Koristi udruga.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Ul. Ivana Viteza Trnskog 12, 43000, Bjelovar, Croatia",
                            Latitude = 45.89985635654719, 
                            Longitude = 16.844103762792447
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                        new VenueEntity
                    {
                        Id = Venue9Id,
                        Name = "Mjesni dom Ciglena",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Ciglena 13, 43000, Bjelovar, Croatia",
                            Latitude = 45.86690725339959,
                            Longitude = 16.936848167895533
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                          new VenueEntity
                    {
                        Id = Venue10Id,
                        Name = "Mjesni dom Gudovac",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Gudovac 31, 43000, Bjelovar, Croatia",
                            Latitude = 45.88096522481425, 
                            Longitude = 16.785438267896385
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                            new VenueEntity
                    {
                        Id = Venue11Id,
                        Name = "Mjesni dom Prgomelje",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Prgomelje 78, 43000, Bjelovar, Croatia",
                            Latitude = 45.889839596181176, 
                            Longitude = 16.738935754404473
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                              new VenueEntity
                    {
                        Id = Venue12Id,
                        Name = "Mjesni dom Patkovac",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Patkovac 30, 43000, Bjelovar, Croatia",
                            Latitude = 45.85278800493055,
                            Longitude = 16.930290722296654
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                                new VenueEntity
                    {
                        Id = Venue13Id,
                        Name = "Mjesni dom Stare plavnice",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Staroplavnička ul. 52, 43000, Bjelovar, Croatia",
                            Latitude = 45.89308444743764, 
                            Longitude = 16.807260181389573
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue14Id,
                        Name = "Mjesni dom Ždralovi",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Ždralovska 20a, 43000, Bjelovar, Croatia",
                            Latitude = 45.87924122293309,
                            Longitude = 16.8812710813888
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue15Id,
                        Name = "Mjesni dom Gornje Plavnice",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Gornje Plavnice 39, 43000, Bjelovar, Croatia",
                            Latitude = 45.94052697165023, 
                            Longitude = 16.854355654407353
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue16Id,
                        Name = "Mjesni dom Galovac",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Galovac ul. 99, 43000, Bjelovar, Croatia",
                            Latitude = 45.84586282261055, 
                            Longitude = 16.851711925566097
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue17Id,
                        Name = "Mjesni dom Kokinac",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Kokinac 43, 43000, Bjelovar, Croatia",
                            Latitude = 45.84627294239657, 
                            Longitude = 16.90366591207361
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue18Id,
                        Name = "Mjesni dom Trojstveni Markovac",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Đurđevačka cesta 148, 43000, Bjelovar, Croatia",
                            Latitude = 45.91863552868665, 
                            Longitude = 16.873272822322452
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue19Id,
                        Name = "Mjesni dom Novoseljani",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Novoseljanska ul. 91, 43000, Bjelovar, Croatia",
                            Latitude = 45.89354781531993, 
                            Longitude = 16.871181110225415
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue20Id,
                        Name = "Mjesni dom Velike sredice",
                        Description = "Trenutno nije za korištenje.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Velike Sredice 100, 43000, Bjelovar, Croatia",
                            Latitude = 45.886395730005766, 
                            Longitude = 16.81952161207597
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue21Id,
                        Name = "Mjesni dom Obrovnica",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Obrovnica 38, 43000, Bjelovar, Croatia",
                            Latitude = 45.82946731632484, 
                            Longitude = 16.874485305093135
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue22Id,
                        Name = "Mjesni dom Brezovac",
                        Description = "Koristi udruga.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Športska ulica 5, 43000, Bjelovar, Croatia",
                            Latitude = 45.875181964054526, 
                            Longitude = 16.838084412129053
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                     new VenueEntity
                    {
                        Id = Venue23Id,
                        Name = "Mjesni dom Prokljuvani",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Prokljuvani 53, 43000, Bjelovar, Croatia",
                            Latitude = 45.902655454823325, 
                            Longitude = 16.89889951207688
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue24Id,
                        Name = "Mjesni dom Veliko Korenovo",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Veliko Korenovo 109A, 43000, Bjelovar, Croatia",
                            Latitude = 45.858389397635605,
                            Longitude = 16.81120361207433
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue25Id,
                        Name = "Mjesni dom Tomaš",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Gornji Tomaš 27a, 43000, Bjelovar, Croatia",
                            Latitude = 45.89517191095263, 
                            Longitude = 16.931455654404786
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue26Id,
                        Name = "Mjesni dom Klokočevac",
                        Description = "Sporska dvorana.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Klokočevac 86, 43000, Bjelovar, Croatia",
                            Latitude = 45.91602041612277, 
                            Longitude = 16.78519693581391
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue27Id,
                        Name = "Mjesni dom Stančići",
                        Description = "Vlasnik DVD.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Stančići 14, 43000, Bjelovar, Croatia",
                            Latitude = 45.90385931926139, 
                            Longitude = 16.756107725569407
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue28Id,
                        Name = "Mjesni dom Prespa",
                        Description = "Potencijalni domovi za korištenje dio DVD.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Prespa 229, 43000, Bjelovar, Croatia",
                            Latitude = 45.864201023050846,
                            Longitude = 16.919209096731304
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue29Id,
                        Name = "Mjesni dom Rajić",
                        Description = "Koriste udruge.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Rajić 73, 43000, Bjelovar, Croatia",
                            Latitude = 45.89896576673113, 
                            Longitude = 16.70594625440496
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue30Id,
                        Name = "Mjesni dom Gornji Tomaš",
                        Description = "Mjesni dom.",
                        IsRentable = true,
                        Location = new Location
                        {
                            FullAddress = "Gornji Tomaš 27a, 43000, Bjelovar, Croatia",
                            Latitude = 45.89511217505349, 
                            Longitude = 16.93143419673309
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue31Id,
                        Name = "Mjesni dom Stari Pavljani",
                        Description = "Koristi udruga.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Stari Pavljani 81, 43000, Bjelovar, Croatia",
                            Latitude = 45.85834789776947, 
                            Longitude = 16.884327381387532
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    },
                      new VenueEntity
                    {
                        Id = Venue32Id,
                        Name = "Mjesni dom Novi Pavljani",
                        Description = "Trenutno nije za korištenje.",
                        IsRentable = false,
                        Location = new Location
                        {
                            FullAddress = "Novi Pavljani 24, 43000, Bjelovar, Croatia",
                            Latitude = 45.85726388496098, 
                            Longitude = 16.84595969673091
                        },
                        TenantId = Tenant1Id,
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
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
                        Capacity = 100,
                        Price = 400,
                        SecurityDeposit = 50
                    }
                }
            });

            await SaveChangesAsync();
        }
    }
}