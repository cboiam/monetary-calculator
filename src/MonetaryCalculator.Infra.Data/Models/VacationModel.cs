using System;

namespace MonetaryCalculator.Infra.Data.Models
{
    public class VacationModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
