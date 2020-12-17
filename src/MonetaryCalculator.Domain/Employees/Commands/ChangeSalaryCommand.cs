using MediatR;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class ChangeSalaryCommand : ICommand, IRequest<bool>
    {
        public int EmployeeId { get; init; }
        public PaymentUnit PaymentUnit { get; init; }
        public decimal PaymentAmount { get; init; }

        public bool IsValid()
        {
            return EmployeeId != default &&
                PaymentAmount > 0;
        }
    }
}
