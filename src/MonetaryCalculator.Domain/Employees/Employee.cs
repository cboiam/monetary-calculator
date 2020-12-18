using System;
using System.Collections.Generic;
using System.Linq;

namespace MonetaryCalculator.Domain.Employees
{
    public class Employee
    {
        public int Id { get; init; }

        private string name;
        public string Name
        {
            get => name; 
            init => name = value;
        }

        public DateTime HiringDate { get; init; }
        public DateTime? LeaveDate { get; init; }
        public LeaveCondition LeaveCondition { get; init; }

        internal Wage CurrentWage => Wages?.Last();
        public List<Wage> Wages { get; init; }

        //public int VacationDaysAvailable => throw new NotImplementedException();
        public List<Vacation> Vacations { get; init; }

        public void ChangeSalary(CountUnit countUnit, decimal amount)
        {
            var newSalary = new Wage
            {
                CountUnit = countUnit,
                Amount = amount
            };

            //if (CurrentWage?.Total > newSalary.Total)
            //{
            //    throw new BusinessException("Can't decrease salary");
            //}

            Wages.Add(newSalary);
        }

        internal void SetName(string name) => this.name = name;
    }
}
