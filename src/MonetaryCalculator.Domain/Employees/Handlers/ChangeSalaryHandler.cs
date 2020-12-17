using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MonetaryCalculator.Domain.Employees.Commands;
using MonetaryCalculator.Domain.Employees.Interfaces;
using MonetaryCalculator.Domain.Employees.Queries;

namespace MonetaryCalculator.Domain.Employees.Handlers
{
    public class ChangeSalaryHandler : IRequestHandler<ChangeSalaryCommand, bool>
    {
        private readonly IEmployeeQueries employeeQuery;
        private readonly IEmployeeRepository employeeRepository;

        public ChangeSalaryHandler(IEmployeeQueries employeeQuery,
            IEmployeeRepository employeeRepository)
        {
            this.employeeQuery = employeeQuery;
            this.employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(ChangeSalaryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return false;
            }

            var employee = await employeeQuery.Get(request.EmployeeId);
            employee.ChangeSalary(request.PaymentUnit, request.PaymentAmount);

            await employeeRepository.ChangeSalary(employee);
            return true;
        }
    }
}
