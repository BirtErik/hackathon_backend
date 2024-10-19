using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class ReservationRequestEntity : BaseEntity
{
    [Column("tenant_id")]
    public required Guid TenantId { get; set; }

    [Column("venue_id")]
    public required Guid VenueId { get; set; }

    [Column("user_id")]
    public required Guid UserId { get; set; }

    [Column("first_name")]
    public required string FirstName { get; set; }

    [Column("last_name")]
    public required string LastName { get; set; }

    [Column("street_address")]
    public required string StreetAddress { get; set; }

    [Column("city")]
    public required string City { get; set; }

    [Column("oib")]
    public required string Oib { get; set; }

    [Column("phone")]
    public required string Phone { get; set; }

    [Column("bank_name")]
    public required string BankName { get; set; }

    [Column("iban")]
    public required string Iban { get; set; }

    [Column("purpose")]
    public required string Purpose { get; set; }

    [Column("start_date")]
    public DateTimeOffset StartDate { get; set; }

    [Column("end_date")]
    public DateTimeOffset EndDate { get; set; }
}
