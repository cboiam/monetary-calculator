using System;
using MediatR;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class DismissEmployeeCommand : ICommand, IRequest<bool>
    {
        public int Id { get; init; }
        public DateTime LeaveDate { get; init; }
        public LeaveCondition LeaveCondition { get; init; }

        public bool IsValid()
        {
            return Id != default &&
                LeaveDate != default;
        }
    }
}
