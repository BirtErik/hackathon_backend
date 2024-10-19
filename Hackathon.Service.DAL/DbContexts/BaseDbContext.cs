using Hackathon.Service.DAL.Constants;
using Hackathon.Service.DAL.Entities;
using Hackathon.Service.DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Hackathon.Service.DAL.DbContexts;

public abstract class BaseDbContext<TDbContext> : DbContext where TDbContext : BaseDbContext<TDbContext>
{
    protected const string DefaultDbSchema = DbSchemaConstants.DefaultDbSchema;

    protected BaseDbContext(DbContextOptions<TDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureTenantEntity(modelBuilder);
        ConfigureVenueEntity(modelBuilder);
        ConfigureReservationRequestEntity(modelBuilder);
        ConfigureContractEntity(modelBuilder);
        ConfigureVenueReportEntity(modelBuilder);

        modelBuilder.HasDefaultSchema(DefaultDbSchema);
        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureTenantEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TenantEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<TenantEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<TenantEntity>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<TenantEntity>().Property(x => x.Description).IsRequired();
    }

    private static void ConfigureVenueEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VenueEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<VenueEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<VenueEntity>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<VenueEntity>().Property(x => x.Description).IsRequired();
        modelBuilder.Entity<VenueEntity>().Property(x => x.IsRentable).IsRequired();
        modelBuilder.Entity<VenueEntity>().Property(x => x.Location).IsRequired();
        modelBuilder.Entity<VenueEntity>().Property(x => x.TenantId).IsRequired();

        // Configure the Location property as a JSON column
        modelBuilder.Entity<VenueEntity>()
            .Property(x => x.Location)
            .IsRequired()
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), // Serialize to JSON
                v => JsonSerializer.Deserialize<Location>(v, (JsonSerializerOptions)null) // Deserialize from JSON
            );

        // Configure the TenantId property as a foreign key
        modelBuilder.Entity<VenueEntity>()
        .HasOne<TenantEntity>() // No navigation property, just specify the related entity
        .WithMany(t => t.Venues) // You can still reference the collection if you have it
        .HasForeignKey(v => v.TenantId); // Specify the foreign key
    }

    private static void ConfigureReservationRequestEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationRequestEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ReservationRequestEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
        // todo: define required properties
        modelBuilder.Entity<ReservationRequestEntity>().Property(x => x.TenantId).IsRequired();



        // Configure relationship between VenueEntity and ReservationRequestEntity
        modelBuilder.Entity<ReservationRequestEntity>()
            .HasOne<VenueEntity>()  // Each ReservationRequest is related to one Venue
            .WithMany(v => v.ReservationRequests)  // One Venue can have many ReservationRequests
            .HasForeignKey(rr => rr.VenueId)  // The foreign key is VenueId
            .OnDelete(DeleteBehavior.Cascade);  // Cascade deletion when a venue is deleted

        // Configure relationship between TenantEntity and ReservationRequestEntity
        modelBuilder.Entity<ReservationRequestEntity>()
            .HasOne<TenantEntity>()  // Each ReservationRequest is related to one Tenant
            .WithMany(t => t.ReservationRequests)  // One Tenant can have many ReservationRequests
            .HasForeignKey(rr => rr.TenantId)  // The foreign key is TenantId
            .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of a tenant if there are reservation requests
    }

    private static void ConfigureContractEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContractEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ContractEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
        // todo: define required properties

        // Configure relationship between VenueEntity and ContractEntity
        modelBuilder.Entity<ContractEntity>()
            .HasOne<VenueEntity>()
            .WithMany(v => v.Contracts)
            .HasForeignKey(vr => vr.VenueId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void ConfigureVenueReportEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VenueReportEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<VenueReportEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
        // todo: define required properties

        modelBuilder.Entity<VenueReportEntity>()
           .HasOne<VenueEntity>()  // Each VenueReport is related to one Venue
           .WithMany(v => v.VenueReports)  // One Venue can have many VenueReports
           .HasForeignKey(vr => vr.VenueId)  // The foreign key is VenueId
           .OnDelete(DeleteBehavior.Cascade);  // Cascade deletion when a venue is deleted
    }

    public DbSet<TenantEntity> Tenants { get; set; } = null!;
    public DbSet<VenueEntity> Venues { get; set; } = null!;
    public DbSet<ContractEntity> Contracts { get; set; } = null!;
    public DbSet<ReservationRequestEntity> ReservationRequests { get; set; } = null!;
    public DbSet<VenueReportEntity> VenueReports { get; set; } = null!;
}
