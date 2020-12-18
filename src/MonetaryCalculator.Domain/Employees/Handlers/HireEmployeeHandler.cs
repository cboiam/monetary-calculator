using MediatR;
using MonetaryCalculator.Domain.Employees.Commands;
using MonetaryCalculator.Domain.Employees.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Handlers
{
    public class HireEmployeeHandler : IRequestHandler<HireEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository employeeRepository;

        public HireEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(HireEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                throw new BusinessException("Hire employee command is invalid");
            }

            var employee = new Employee
            {
                Name = request.Name,
                HiringDate = request.HiringDate,
                Wages = new List<Wage>
                {
                    new Wage
                    {
                        Amount = request.Amount,
                        CountUnit = request.CountUnit
                    }
                }
            };

            return await employeeRepository.Create(employee);
        }
    }
}
