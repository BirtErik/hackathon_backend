using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class TenantEntity : BaseEntity
{
    [Column("name")]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    public ICollection<VenueEntity> Venues { get; set; } = new List<VenueEntity>();

    public ICollection<ReservationRequestEntity> ReservationRequests { get; set; } = new List<ReservationRequestEntity>();

}
