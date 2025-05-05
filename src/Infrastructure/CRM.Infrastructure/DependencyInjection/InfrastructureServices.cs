namespace CRM.Infrastructure.DependencyInjection;
public static class InfrastructureServices
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
						options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

		return services;
	}
}
