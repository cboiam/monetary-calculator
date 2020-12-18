using MonetaryCalculator.Domain.Employees;
using System;
using System.Collections.Generic;

namespace MonetaryCalculator.Infra.Data.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public bool Dismissed { get; set; }
        public LeaveCondition LeaveCondition { get; set; }

        public IEnumerable<WageModel> Wages { get; set; }
        public IEnumerable<VacationModel> Vacations { get; set; }
    }
}
