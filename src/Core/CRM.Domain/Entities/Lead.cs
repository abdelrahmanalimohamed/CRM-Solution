namespace CRM.Domain.Entities;
public class Lead : EntityBase
{
	private Lead(
		Guid id , 
		Email email , 
		string name ,
		Company company ,
		LeadStatus status) : base(id)
	{
		Email = email;
		Name = name;
		LeadStatus = status;
		Company = company;
		RaiseDomainEvent(new LeadCreated(id, name, email, company));
	}
	public Email Email { get; private set; }
	public string Name { get; private set; }
	public Company Company { get; private set; }
	public LeadStatus LeadStatus { get; private set; }
	public static Lead CreateLead(
		Email email , 
		string Name ,
		Company Company)
	{
		var lead = new Lead(
			Guid.NewGuid(),
			email,
			Name,
			Company,
			LeadStatus.New);

		return lead;
	}
}