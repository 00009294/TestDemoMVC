using Microsoft.EntityFrameworkCore;
using TestDemoMVC.DbContexts;
using TestDemoMVC.Models;

namespace TestDemoMVC.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetAsync(CancellationToken cancellationToken)
        {
            var employees = await _appDbContext.Employees
                .AsNoTracking()
                .OrderBy(a => a.Column2)
                .ToListAsync(cancellationToken);

            return employees;
        }

        public async Task AddAsync(IEnumerable<Employee> employees, CancellationToken cancellationToken)
        {
            if(employees == null)
            {
                throw new ArgumentNullException(nameof(employees));
            }

            await _appDbContext.Employees.AddRangeAsync(employees);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            var selectedEmployee = _appDbContext.Employees.FirstOrDefault(a => a.Id == employee.Id);
           
            if (selectedEmployee == null)
            {
                throw new ArgumentNullException();
            }

            selectedEmployee.Column1 = employee.Column1;
            selectedEmployee.Column2 = employee.Column2;
            selectedEmployee.Column3 = employee.Column3;
            selectedEmployee.Column4 = employee.Column4;
            selectedEmployee.Column5 = employee.Column5;

            _appDbContext.Employees.Update(selectedEmployee);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var employee = await _appDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if(employee == null)
            {
                return;
            }

            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}