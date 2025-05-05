namespace CRM.Domain.Entities;
public class Deal : EntityBase
{
	public Deal(
		Guid Id , 
		string title , 
		decimal amount , 
		DealStage dealStage ,
		DateOnly expectedCloseDate , 
		Company company ,
		List<Contact> contacts , 
		User assignedTo) : base(Id)
	{
		Title = title;
		Amount = amount;
		DealStage  = dealStage;
		ExpectedCloseDate = expectedCloseDate;
		Company = company;
		Contacts = contacts;
		AssignedTo = assignedTo;
		RaiseDomainEvent(new DealCreated(Id, title, amount, dealStage, expectedCloseDate , company , contacts , assignedTo));
	}
	public string Title { get; private set; }
	public decimal Amount { get; private set; }
	public DealStage DealStage { get; private set; }
	public DateOnly ExpectedCloseDate { get; private set; }
	public Company Company { get; private set; }
	public List<Contact> Contacts { get; private set; } = new ();
	public User AssignedTo { get; private set; }
}