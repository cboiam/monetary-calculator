using System;
using MediatR;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class HireEmployeeCommand : ICommand, IRequest<bool>
    {
        public string Name { get; init; }
        public DateTime HiringDate { get; init; }
        public Payment Payment { get; init; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                HiringDate != default &&
                Payment != null &&
                Payment.PaymentAmount > 0;
        }
    }
}
