using System;

namespace MonetaryCalculator.Host.Responses
{
    public class EmployeeResumedResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime HiringDate { get; init; }
        public DateTime? LeaveDate { get; init; }
    }
}
