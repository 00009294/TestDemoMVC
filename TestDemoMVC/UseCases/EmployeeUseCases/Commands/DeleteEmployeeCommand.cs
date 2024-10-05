using MediatR;
using TestDemoMVC.Repositories.EmployeeRepository;

namespace TestDemoMVC.UseCases
{
    public record DeleteEmployeeCommand(int id) : IRequest
    {
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.id, cancellationToken);
        }
    }
}
