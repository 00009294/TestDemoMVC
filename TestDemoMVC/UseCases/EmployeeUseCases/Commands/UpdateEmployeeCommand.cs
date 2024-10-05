using MediatR;
using TestDemoMVC.Models;
using TestDemoMVC.Repositories.EmployeeRepository;

namespace TestDemoMVC.UseCases
{
    public record UpdateEmployeeCommand(Employee Employee) : IRequest
    {
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(request.Employee, cancellationToken);
        }
    }
}
