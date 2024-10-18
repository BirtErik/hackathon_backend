using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class VenueRoomEntity : BaseEntity
{
    [Column("venue_id")]
    public Guid VenueId { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("capacity")]
    public required int Capacity { get; set; }

    [Column("is_rentable")]
    public required bool IsRentable { get; set; }
}
