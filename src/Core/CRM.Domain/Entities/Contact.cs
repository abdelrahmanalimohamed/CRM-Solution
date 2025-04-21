namespace CRM.Domain.Entities;
public class Contact : EntityBase
{
	public Contact(
		Guid Id , 
		string name , 
		Email email , 
		PhoneNumber phoneNumber) : base(Id)
	{
		Name = name;
		Email = email;
		PhoneNumber = phoneNumber;
	}
	public string Name { get; private set; }
	public Email Email { get; private set; }
	public PhoneNumber PhoneNumber { get; private set; }
}
