using System;
using MediatR;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class HireEmployeeCommand : ICommand, IRequest<Employee>
    {
        public string Name { get; init; }
        public DateTime HiringDate { get; init; }
        public CountUnit CountUnit { get; init; }
        public decimal Amount { get; init; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                HiringDate != default &&
                Amount > 0;
        }
    }
}
