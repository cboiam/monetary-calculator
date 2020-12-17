using System;
using System.Collections.Generic;
using MonetaryCalculator.Domain.Vacations;

namespace MonetaryCalculator.Domain.Employees
{
    public class Employee
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime HiringDate { get; init; }
        public DateTime? LeaveDate { get; init; }

        private Payment payment;
        public Payment Payment
        {
            get => payment;
            init => payment = value;
        }

        public int VacationDaysAvailable => throw new NotImplementedException();
        public List<Vacation> Vacations { get; init; }

        public void ChangeSalary(PaymentUnit paymentUnit, decimal paymentAmount)
        {
            var newSalary = new Payment
            {
                PaymentUnit = paymentUnit,
                PaymentAmount = paymentAmount
            };

            if (Payment.Total > newSalary.Total)
            {
                throw new ArgumentException("Can't decrease salary");
            }

            payment = newSalary;
        }
    }
}
