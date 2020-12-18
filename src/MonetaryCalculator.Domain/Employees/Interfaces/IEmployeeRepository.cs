using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
    }
}
