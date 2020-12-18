using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MonetaryCalculator.Domain.Employees.Commands;
using MonetaryCalculator.Domain.Employees.Interfaces;
using MonetaryCalculator.Domain.Employees.Queries;

namespace MonetaryCalculator.Domain.Employees.Handlers
{
    public class ChangeSalaryHandler : IRequestHandler<ChangeSalaryCommand, Wage>
    {
        private readonly IEmployeeQuery employeeQuery;
        private readonly IWageRepository wageRepository;

        public ChangeSalaryHandler(IEmployeeQuery employeeQuery,
            IWageRepository wageRepository)
        {
            this.employeeQuery = employeeQuery;
            this.wageRepository = wageRepository;
        }

        public async Task<Wage> Handle(ChangeSalaryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                throw new BusinessException("Change salary command is invalid");
            }

            var employee = await employeeQuery.Get(request.EmployeeId, cancellationToken);
            employee.ChangeSalary(request.CountUnit, request.Amount);

            return await wageRepository.Create(employee.Id, employee.Wages.Last());
        }
    }
}
