using CRM.SharedKernel.Events;

namespace CRM.SharedKernel.Base;

/// <summary>
/// Base class for all domain entities
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Unique identifier for the entity
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Version for optimistic concurrency
    /// </summary>
    public int Version { get; protected set; }

    private List<DomainEventsBase> _domainEvents;
    
    /// <summary>
    /// Collection of domain events raised by this entity
    /// </summary>
    public IReadOnlyCollection<DomainEventsBase> DomainEvents => _domainEvents?.AsReadOnly();

    protected EntityBase()
    {
        Id = Guid.NewGuid();
        Version = 1;
    }

    /// <summary>
    /// Constructor for reconstructing entities from persistence
    /// </summary>
    /// <param name="id">The existing ID of the entity</param>
    /// <param name="version">The current version of the entity</param>
    protected EntityBase(Guid id, int version = 1)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty", nameof(id));
            
        Id = id;
        Version = version;
    }

    /// <summary>
    /// Adds a domain event to this entity
    /// </summary>
    /// <param name="domainEvent">The domain event to add</param>
    public void AddDomainEvent(DomainEventsBase domainEvent)
    {
        _domainEvents ??= new List<DomainEventsBase>();
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Removes a domain event from this entity
    /// </summary>
    /// <param name="domainEvent">The domain event to remove</param>
    public void RemoveDomainEvent(DomainEventsBase domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    /// <summary>
    /// Clears all domain events from this entity
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    /// <summary>
    /// Increments the version number for optimistic concurrency
    /// </summary>
    protected void IncrementVersion()
    {
        Version++;
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (obj is not EntityBase other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        if (Id == Guid.Empty || other.Id == Guid.Empty) return false;
        return Id == other.Id;
    }

    public static bool operator ==(EntityBase a, EntityBase b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(EntityBase a, EntityBase b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }
}