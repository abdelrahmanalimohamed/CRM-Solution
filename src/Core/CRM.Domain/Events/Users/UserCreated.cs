using CRM.Domain.Entities;
using CRM.SharedKernel.Events;

namespace CRM.Domain.Events.Users;
public sealed class UserCreated : DomainEventsBase
{
	public string UserName { get; }
	public Email Email { get; }
	public string FirstName { get; }
	public string LastName { get; }
	public Roles Role { get; }
	public UserCreated(
		Guid Id , 
		string username ,
		Email email , 
		string firstName , 
		string lastName ,
		Roles role) : base(typeof(User) , Id)
	{
		UserName = username;
		Email = email;
		FirstName = firstName;
		LastName = lastName;
		Role = role;
	}
}
