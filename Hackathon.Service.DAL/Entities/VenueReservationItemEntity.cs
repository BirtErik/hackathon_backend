using Hackathon.Service.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class VenueReservationItemEntity : BaseEntity
{
    [Column("venue_reservation_id")]
    public Guid VenueReservationId { get; set; } // Foreign key for the reservation

    [Column("name")]
    public required string Name { get; set; }

    [Column("price")]
    public required double Price { get; set; }

    [Column("quantity")]
    public required int Quantity { get; set; }
}