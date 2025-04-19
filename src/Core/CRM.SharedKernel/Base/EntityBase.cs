using CRM.SharedKernel.Events;

namespace CRM.SharedKernel.Base;
public abstract class EntityBase
{
	private readonly List<DomainEventsBase> _domainEvents = new();
	public IReadOnlyCollection<DomainEventsBase> DomainEvents => _domainEvents.AsReadOnly();
	protected EntityBase(Guid id)
	{
		Id = id;
	}
	public Guid Id { get; init; }
	public IReadOnlyList<DomainEventsBase> GetDomainEvents()
	{
		return _domainEvents.ToList();
	}
	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}
	protected void RaiseDomainEvent(DomainEventsBase domainEvent)
	{
		_domainEvents.Add(domainEvent);
	}
}
