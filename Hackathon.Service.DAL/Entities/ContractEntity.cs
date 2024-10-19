using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class ContractEntity : BaseEntity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("venue_id")]
    public Guid VenueId { get; set; }

    [Column("first_name")]
    public required string FirstName { get; set; }

    [Column("last_name")]
    public required string LastName { get; set; }

    [Column("oib")]
    public required string Oib { get; set; }

    [Column("address")]
    public required string Address { get; set; }

    [Column("post_number")]
    public required string PostNumber { get; set; }

    [Column("place")]
    public required string Place { get; set; }

    [Column("venue_name")]
    public required string VenueName { get; set; }

    [Column("venue_address")]
    public required string VenueAddress { get; set; }

    [Column("start_date")]
    public DateTimeOffset StartDate { get; set; }

    [Column("end_date")]
    public DateTimeOffset EndDate { get; set; }

    [Column("price")]
    public required double Price { get; set; }

    [Column("deposit")]
    public required double Deposit { get; set; }

    [Column("bills")]
    public required double Bills { get; set; }

    [Column("vat")]
    public required double Vat { get; set; }

    [Column("status")]
    public required string Status { get; set; }
}
