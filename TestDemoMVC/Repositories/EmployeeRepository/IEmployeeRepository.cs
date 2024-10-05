using TestDemoMVC.Models;

namespace TestDemoMVC.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAsync(CancellationToken cancellationToken);
        Task AddAsync(IEnumerable<Employee> employees, CancellationToken cancellationToken);
        Task UpdateAsync(Employee employee, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
