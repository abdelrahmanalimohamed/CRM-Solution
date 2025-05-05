namespace CRM.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	  : base(options)
	{
	}
	public DbSet<User> Users { get; set; }
	public DbSet<Lead> Leads { get; set; }
	public DbSet<Domain.Entities.Task> Tasks { get; set; }
	public DbSet<Deal> Deals { get; set; }
	public DbSet<Interaction> Interactions { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}
}