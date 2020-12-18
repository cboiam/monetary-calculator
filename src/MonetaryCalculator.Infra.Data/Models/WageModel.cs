using MonetaryCalculator.Domain.Employees;

namespace MonetaryCalculator.Infra.Data.Models
{
    public class WageModel
    {
        public int Id { get; set; }
        public CountUnit CountUnit { get; set; }
        public decimal Amount { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
