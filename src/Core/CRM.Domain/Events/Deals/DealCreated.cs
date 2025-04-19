using CRM.Domain.Entities;
using CRM.SharedKernel.Events;

namespace CRM.Domain.Events.Deals;
public class DealCreated : DomainEventsBase
{
	public string Title { get; }
	public decimal Amount { get; }
	public DealStage DealStage { get;  }
	public DateOnly ExpectedCloseDate { get; }
	public Company Company { get; }
	public List<Contact> Contacts { get; }
	public User AssignedTo { get; }
	public DealCreated(
		Guid dealId ,
		string title ,
		decimal amount ,
		DealStage dealStage , 
		DateOnly expectedCloseDate, 
		Company company , 
		List<Contact> contacts , 
		User assinedTo) : base(typeof(Deal), dealId)
	{
		Title = title;
		Amount = amount;
		DealStage = dealStage;
		ExpectedCloseDate = expectedCloseDate;
		Company = company;
		Contacts = contacts;
		AssignedTo = assinedTo;
	}
}
