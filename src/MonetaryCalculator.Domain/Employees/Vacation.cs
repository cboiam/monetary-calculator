using System;

namespace MonetaryCalculator.Domain.Employees
{
    public class Vacation
    {
        public int Id { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        //public int Days => throw new NotImplementedException();
    }
}
