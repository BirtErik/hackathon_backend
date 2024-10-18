using Hackathon.Service.DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Service.DAL.Entities;

public abstract class BaseEntity : IBaseEntity
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; internal set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; internal set; }

    [Column("deleted_at")]
    public DateTimeOffset? DeletedAt { get; internal set; }
}

