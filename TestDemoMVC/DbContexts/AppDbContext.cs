using Microsoft.EntityFrameworkCore;
using TestDemoMVC.Models;

namespace TestDemoMVC.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
