namespace CRM.Domain.Entities;
public class User : EntityBase
{
	public User(
		Guid Id , 
		string userName , 
		Email email ,
		string firstName , 
		string lastName , 
		Roles role , 
		List<Interaction> activities , 
		List<Task> tasks) : base(Id)
	{
		Username = userName;
		Email = email;
		FirstName = firstName;
		LastName = lastName;
		Role = role;
		Activities = activities;
		Tasks = tasks;
	}
	public string Username { get; private set; }
	public Email Email { get; private set; }
	public string FirstName { get; private set; }
	public string LastName { get; private set; }
	public Roles Role { get; private set; }
	public List<Interaction> Activities { get; set; } = new();
	public List<Task> Tasks { get; private set; } = new();
}