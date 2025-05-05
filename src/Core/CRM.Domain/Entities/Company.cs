namespace CRM.Domain.Entities;
public class Company : EntityBase
{
	public Company(
		Guid Id ,
		string name , 
		string industry , 
		string size ,
		List<Contact> contact) : base(Id)
	{
		Name = name;
		Industry = industry;
		Size = size;
		Contact = contact;
	}
	public string Name { get; private set; }
	public string Industry { get; private set; }
	public string Size { get; private set; }
	public List<Contact> Contact { get; private set; } = new(); 
}