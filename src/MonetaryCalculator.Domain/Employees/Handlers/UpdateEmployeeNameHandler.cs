using MediatR;
using MonetaryCalculator.Domain.Employees.Commands;
using MonetaryCalculator.Domain.Employees.Interfaces;
using MonetaryCalculator.Domain.Employees.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Handlers
{
    public class UpdateEmployeeNameHandler : IRequestHandler<UpdateEmployeeNameCommand, bool>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeQuery employeeQuery;

        public UpdateEmployeeNameHandler(IEmployeeRepository employeeRepository, 
            IEmployeeQuery employeeQuery)
        {
            this.employeeRepository = employeeRepository;
            this.employeeQuery = employeeQuery;
        }

        public async Task<bool> Handle(UpdateEmployeeNameCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid())
            {
                throw new BusinessException("Update employee name command is invalid");
            }

            var employee = await employeeQuery.Get(request.Id);
            employee.SetName(request.Name);

            await employeeRepository.Update(employee);
            return true;
        }
    }
}
