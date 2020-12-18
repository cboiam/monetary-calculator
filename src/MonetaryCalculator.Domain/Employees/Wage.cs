using System;

namespace MonetaryCalculator.Domain.Employees
{
    public class Wage
    {
        private int id;
        public int Id
        {
            get => id;
            init => id = value;
        }

        public CountUnit CountUnit { get; init; }
        public decimal Amount { get; init; }
        //public decimal Total => throw new NotImplementedException();

        internal void SetId(int id) => this.id = id;
    }
}
