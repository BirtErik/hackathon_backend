using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class VenueReservationEntity : BaseEntity
{
    [Column("venue_id")]
    public Guid VenueId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("start_date")]
    public DateTimeOffset StartDate { get; set; }

    [Column("end_date")]
    public DateTimeOffset EndDate { get; set; }

    [Column("contact_email")]
    public string ContactEmail { get; set; } = null!;

    public ICollection<VenueReservationItemEntity> ReservationItems { get; set; } = new List<VenueReservationItemEntity>();
}
