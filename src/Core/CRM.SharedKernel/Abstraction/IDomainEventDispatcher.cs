using CRM.SharedKernel.Base;

namespace CRM.SharedKernel.Abstraction;

/// <summary>
/// Dispatches domain events from entities
/// </summary>
public interface IDomainEventDispatcher
{
	/// <summary>
	/// Dispatches all domain events from the given entities
	/// </summary>
	/// <param name="entities">The entities containing domain events to dispatch</param>
	/// <param name="cancellationToken">Optional cancellation token</param>
	/// <returns>A task representing the asynchronous operation</returns>
	Task DispatchAsync(IEnumerable<EntityBase> entities, CancellationToken cancellationToken = default);
}