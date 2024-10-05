using Microsoft.EntityFrameworkCore;
using TestDemoMVC.DbContexts;

namespace TestDemoMVC.Configurations
{
    public static class ConfigureDatabases
    {
        public static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
