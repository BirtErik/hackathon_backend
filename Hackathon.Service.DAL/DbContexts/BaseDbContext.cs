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
        ConfigureVenueEntity(modelBuilder);
        ConfigureTenantEntity(modelBuilder);
        ConfigureVenueReservationModel(modelBuilder);

        modelBuilder.HasDefaultSchema(DefaultDbSchema);
        base.OnModelCreating(modelBuilder);
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

        // Configure the relationship between VenueEntity and VenueItemEntity
        modelBuilder.Entity<VenueEntity>()
            .HasMany(v => v.Items)
            .WithOne()
            .HasForeignKey(i => i.VenueId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure relationship between VenueEntity and VenueReservationEntity
        modelBuilder.Entity<VenueReservationEntity>()
            .HasOne<VenueEntity>()
            .WithMany(v => v.Reservations)
            .HasForeignKey(vr => vr.VenueId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void ConfigureTenantEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TenantEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<TenantEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<TenantEntity>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<TenantEntity>().Property(x => x.Description).IsRequired();
    }

    private void ConfigureVenueReservationModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VenueReservationEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<VenueReservationEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<VenueReservationEntity>().Property(x => x.VenueId).IsRequired();
        modelBuilder.Entity<VenueReservationEntity>().HasMany(x => x.ReservationItems)
            .WithOne()
            .IsRequired()
            .HasForeignKey(x => x.VenueReservationId);
        modelBuilder.Entity<VenueReservationEntity>().Property(x => x.StartDate).IsRequired();
        modelBuilder.Entity<VenueReservationEntity>().Property(x => x.EndDate).IsRequired();
    }

    public DbSet<TenantEntity> Tenants { get; set; } = null!;
    public DbSet<VenueEntity> Venues { get; set; } = null!;
    public DbSet<VenueReservationEntity> VenueReservations { get; set; } = null!;
    public DbSet<VenueReservationItemEntity> VenueReservationItems { get; set; } = null!;
    public DbSet<VenueItemEntity> venueItemEntities { get; set; } = null!;

}
