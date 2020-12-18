using MonetaryCalculator.Domain.Employees;
using System;
using System.Collections.Generic;

namespace MonetaryCalculator.Host.Responses
{
    public class EmployeeDetailedResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime HiringDate { get; init; }
        public DateTime? LeaveDate { get; init; }
        public LeaveCondition LeaveCondition { get; init; }
        public IEnumerable<Wage> Wages { get; init; }
        public IEnumerable<Vacation> Vacations { get; init; }
    }
}
