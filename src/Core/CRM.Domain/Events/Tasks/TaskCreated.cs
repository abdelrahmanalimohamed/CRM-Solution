using CRM.Domain.Entities;
using CRM.SharedKernel.Events;

namespace CRM.Domain.Events.Tasks;
public sealed class TaskCreated : DomainEventsBase
{
	public string Name { get;  }
	public DateRange DateRange { get; }
	public User AssingedTo { get; }
	public TaskCreated(
		Guid taskId , 
		string name , 
		DateRange dateRange , 
		User assignedTo) : base(typeof(Entities.Task), taskId)
	{
		Name = name;
		DateRange = dateRange;
		AssingedTo = assignedTo;
	}
}