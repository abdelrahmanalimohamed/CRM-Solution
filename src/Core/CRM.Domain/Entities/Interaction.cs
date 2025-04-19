namespace CRM.Domain.Entities;
public class Interaction : EntityBase
{
	public Interaction(
		Guid Id , 
		ActivityType activityType , 
		string subject ,
		string desciption ,
		DateRange dateRange ,
		User assignedTo) : base(Id)
	{
		Type = activityType;
		Subject = subject;
		Description = desciption;
		DateRange = dateRange;
		AssignedTo = assignedTo;
	}
	public ActivityType Type { get; private set; }
	public string Subject { get; private set; }
	public string Description { get; private set; }
	public DateRange DateRange { get; private set; }
	public User AssignedTo { get; private set; }
}