using MediatR;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class ChangeSalaryCommand : ICommand, IRequest<Wage>
    {
        public int EmployeeId { get; init; }
        public CountUnit CountUnit { get; init; }
        public decimal Amount { get; init; }

        public bool IsValid() => EmployeeId != default && Amount > 0;
    }
}
