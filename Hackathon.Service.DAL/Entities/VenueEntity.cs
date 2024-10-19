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

    [Column("capacity")]
    public required int Capacity { get; set; }

    [Column("price")]
    public required double Price { get; set; }

    [Column("security_deposit")]
    public required double SecurityDeposit { get; set; }

    public ICollection<ReservationRequestEntity> ReservationRequests { get; set; } = new List<ReservationRequestEntity>();

    public ICollection<VenueReportEntity> VenueReports { get; set; } = new List<VenueReportEntity>();

    public ICollection<ContractEntity> Contracts { get; set; } = new List<ContractEntity>();
}
