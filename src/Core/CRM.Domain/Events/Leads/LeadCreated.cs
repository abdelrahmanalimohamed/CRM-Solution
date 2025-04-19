using CRM.Domain.Entities;
using CRM.SharedKernel.Events;

namespace CRM.Domain.Events.Leads;
public class LeadCreated : DomainEventsBase
{
	public Email Email { get;}
	public string Name { get;}
	public Company Company { get;}
	public LeadCreated(Guid LeadId , 
		string name , 
		Email email , 
		Company company)
		: base(typeof(Lead) , LeadId)
	{
		Email = email;
		Company = company;
		Name = name;
	}
}
