using TestDemoMVC.Repositories.EmployeeRepository;

namespace TestDemoMVC.Configurations
{
    public static class ConfigureRepositories 
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
