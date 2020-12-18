using MediatR;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class ChangeSalaryCommand : ICommand, IRequest<Wage>
    {
        public int EmployeeId { get; private set; }
        public CountUnit CountUnit { get; init; }
        public decimal Amount { get; init; }

        public void SetEmployeeId(int id) => EmployeeId = id;
        public bool IsValid() => EmployeeId != default && Amount > 0;
    }
}
