using MediatR;

namespace CRM.SharedKernel.Events;

/// <summary>
/// Base class for all domain events
/// </summary>
public abstract class DomainEventsBase : INotification
{
	/// <summary>
	/// Unique identifier for this event
	/// </summary>
	public Guid EventId { get; }

	/// <summary>
	/// When the event occurred
	/// </summary>
	public DateTime DateOccurred { get; protected set; }

	/// <summary>
	/// Type of the entity that raised this event
	/// </summary>
	public Type SourceType { get; protected set; }

	/// <summary>
	/// Id of the entity that raised this event
	/// </summary>
	public Guid SourceId { get; protected set; }

	protected DomainEventsBase(Type sourceType, Guid sourceId)
	{
		EventId = Guid.NewGuid();
		DateOccurred = DateTime.UtcNow;
		SourceType = sourceType ?? throw new ArgumentNullException(nameof(sourceType));
		SourceId = sourceId;
	}
}
