using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public class VenueReportEntity : BaseEntity
{
    [Column("venue_id")]
    public Guid VenueId { get; set; }

    [Column("venue_name")]
    public required string VenueName { get; set; }

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

    [Column("state_before_usage")]
    public required string StateBeforeUsage { get; set; }

    [Column("state_after_usage")]
    public required string StateAfterUsage { get; set; }

    [Column("damage")]
    public required string Damage { get; set; }

    [Column("problems")]
    public required string Problems { get; set; }

    [Column("inspection_date")]
    public DateTimeOffset InspectionDate { get; set; }
}
