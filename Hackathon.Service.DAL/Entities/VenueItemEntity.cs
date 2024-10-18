using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class VenueItemEntity : BaseEntity
{
    [Column("venue_id")]
    public Guid VenueId { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("price")]
    public required double Price { get; set; }

    [Column("quantity")]
    public required int Quantity { get; set; }
}
