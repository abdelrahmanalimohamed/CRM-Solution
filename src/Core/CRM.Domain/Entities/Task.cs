using CRM.Domain.Events.Tasks;

namespace CRM.Domain.Entities;
public class Task : EntityBase
{
	public Task(
		Guid id , 
		string name , 
		DateRange dateRange ,
		User assingedTo) : base(id)
	{
		Name = name;
		AssignedTo = assingedTo;
		DateRange = dateRange;
		RaiseDomainEvent(new TaskCreated(id, name, dateRange, assingedTo));
	}
	public string Name { get; private set; }
	public DateRange DateRange { get; private set; }
	public User AssignedTo { get; private set; }
	public DateTime? CompletedAt { get; private set; }
	public void Complete()
	{
		if (CompletedAt.HasValue)
		{
			return;
		}

		CompletedAt = DateTime.UtcNow;
		//RaiseDomainEvent(new ActionItemCompleted(Id, Name));
	}

	public void Reassign(User newAssignee)
	{
		if (newAssignee == null)
		{
			throw new ArgumentNullException(nameof(newAssignee));
		}

		AssignedTo = newAssignee;
		//RaiseDomainEvent(new ActionItemReassigned(Id, newAssignee.Id));
	}
}