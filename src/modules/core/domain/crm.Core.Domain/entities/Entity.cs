namespace crm.Core.Domain.entities;

public abstract class Entity
{
    public Guid? Id { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Entity(Guid id = default, DateTime? createdAt = default, DateTime? updatedAt = default)
    {

        Id = !id.Equals(Guid.Empty) ? id : Guid.NewGuid();
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = updatedAt;
    }
}
