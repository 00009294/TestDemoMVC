using MediatR;
using TestDemoMVC.Models;
using TestDemoMVC.Repositories.EmployeeRepository;

namespace TestDemoMVC.UseCases
{
    public class ImportEmployeesCommand : IRequest<(int, List<Employee>)>
    {
        public Stream FileStream { get; }
        public ImportEmployeesCommand(Stream fileStream)
        {
            FileStream = fileStream;
        }
    }

    public class ImportEmployeesCommandHandler : IRequestHandler<ImportEmployeesCommand, (int, List<Employee>)>
    {
        private readonly IEmployeeRepository _repository;
        public ImportEmployeesCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<(int, List<Employee>)> Handle(ImportEmployeesCommand request, CancellationToken cancellationToken)
        {
            var employees = new List<Employee>();
            int processedRows = 0;

            using (var reader = new StreamReader(request.FileStream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    try
                    {
                        var employee = new Employee
                        {
                            Column1 = values.ElementAtOrDefault(0) ?? string.Empty,
                            Column2 = values.ElementAtOrDefault(1) ?? string.Empty,
                            Column3 = values.ElementAtOrDefault(2) ?? string.Empty,
                            Column4 = values.ElementAtOrDefault(3) ?? string.Empty,
                            Column5 = values.ElementAtOrDefault(4) ?? string.Empty,
                            Column6 = values.ElementAtOrDefault(5) ?? string.Empty,
                            Column7 = values.ElementAtOrDefault(6) ?? string.Empty,
                            Column8 = values.ElementAtOrDefault(7) ?? string.Empty,
                            Column9 = values.ElementAtOrDefault(8) ?? string.Empty,
                            Column10 = values.ElementAtOrDefault(9) ?? string.Empty,
                            Column11 = values.ElementAtOrDefault(10) ?? string.Empty,
                            Column12 = values.ElementAtOrDefault(11) ?? string.Empty,
                            OtherInfo = values.ElementAtOrDefault(12) ?? string.Empty,
                            OtherInfo1 = values.ElementAtOrDefault(13) ?? string.Empty,
                            OtherInfo2 = values.ElementAtOrDefault(14) ?? string.Empty,
                            OtherInfo3 = values.ElementAtOrDefault(15) ?? string.Empty,
                            OtherInfo4 = values.ElementAtOrDefault(16) ?? string.Empty,
                            OtherInfo5 = values.ElementAtOrDefault(17) ?? string.Empty,
                            OtherInfo6 = values.ElementAtOrDefault(18) ?? string.Empty,
                            OtherInfo7 = values.ElementAtOrDefault(19) ?? string.Empty,
                            OtherInfo8 = values.ElementAtOrDefault(20) ?? string.Empty,
                            OtherInfo9 = values.ElementAtOrDefault(21) ?? string.Empty,
                        };

                        employees.Add(employee);
                        processedRows++;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }

            await _repository.AddAsync(employees, cancellationToken);

            return (processedRows, employees);
        }

    }

}
