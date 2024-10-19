using Hackathon.Service.DAL.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class VenueEntity : BaseEntity
{
    [Column("tenantId")]
    public required Guid TenantId { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("is_rentable")]
    public required bool IsRentable { get; set; }

    [Column("location")]
    public required Location Location { get; set; }

    public ICollection<VenueItemEntity> Items { get; set; } = new List<VenueItemEntity>();

    public ICollection<VenueReservationEntity> Reservations { get; set; } = new List<VenueReservationEntity>();
}
