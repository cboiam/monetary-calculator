using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Interfaces
{
    public interface IEmployeeRepository
    {
         Task ChangeSalary(Employee employee);
    }
}
