using CRM.Domain.Entities;
using CRM.SharedKernel.Events;

namespace CRM.Domain.Events.Interactions;
public sealed class InteractionCreated : DomainEventsBase
{
	public ActivityType ActivityType { get;  }
	public string Subject { get; }
	public string Desciption { get; }
	public DateRange DateRange { get; }
	public User AssignedTo { get; }

	public InteractionCreated(Guid Id ,
		ActivityType activityType ,
		string subject , 
		string description ,
		DateRange dateRange , 
		User assignedTo) : base(typeof(Interaction) , Id)
	{
		ActivityType = activityType;
		Subject = subject;
		Desciption = description;
		DateRange = dateRange;
		AssignedTo = assignedTo;
	}
}
