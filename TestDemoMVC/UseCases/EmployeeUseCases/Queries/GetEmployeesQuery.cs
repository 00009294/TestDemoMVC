using MediatR;
using TestDemoMVC.Models;
using TestDemoMVC.Repositories.EmployeeRepository;

namespace TestDemoMVC.UseCases
{
    public record GetEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _repository;
        public GetEmployeesQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAsync(cancellationToken);

            return employees;
        }
    }
}
