using System;

namespace MonetaryCalculator.Domain.Employees
{
    public class Payment
    {
        public PaymentUnit PaymentUnit { get; init; }
        public decimal PaymentAmount { get; init; }
        public decimal Total => throw new NotImplementedException();
    }
}
