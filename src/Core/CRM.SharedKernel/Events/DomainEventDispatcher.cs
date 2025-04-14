using CRM.SharedKernel.Abstraction;
using CRM.SharedKernel.Base;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace CRM.SharedKernel.Events;

/// <summary>
/// Implementation of IDomainEventDispatcher that uses MediatR to publish events
/// </summary>
public class DomainEventDispatcher : IDomainEventDispatcher
{
	private readonly IMediator _mediator;
	private readonly ILogger<DomainEventDispatcher> _logger;

	public DomainEventDispatcher(IMediator mediator, ILogger<DomainEventDispatcher> logger)
	{
		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	public async Task DispatchAsync(IEnumerable<EntityBase> entities, CancellationToken cancellationToken = default)
	{
		if (entities == null) throw new ArgumentNullException(nameof(entities));

		_logger.LogInformation("Starting to dispatch domain events for {Count} entities", entities.Count());

		foreach (var entity in entities)
		{
			var events = entity.DomainEvents.ToArray();
			entity.ClearDomainEvents();

			_logger.LogInformation("Processing {EventCount} events for entity {EntityId} of type {EntityType}", 
				events.Length, entity.Id, entity.GetType().Name);

			foreach (var domainEvent in events)
			{
				try
				{
					_logger.LogInformation("Dispatching domain event {EventId} from {SourceType} with ID {SourceId}", 
						domainEvent.EventId, domainEvent.SourceType.Name, domainEvent.SourceId);
					
					await _mediator.Publish(domainEvent, cancellationToken)
						.ConfigureAwait(false);

					_logger.LogInformation("Successfully dispatched domain event {EventId}", domainEvent.EventId);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error dispatching domain event {EventId} from {SourceType} with ID {SourceId}", 
						domainEvent.EventId, domainEvent.SourceType.Name, domainEvent.SourceId);
					throw;
				}
			}
		}

		_logger.LogInformation("Completed dispatching all domain events");
	}
}