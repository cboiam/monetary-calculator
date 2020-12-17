using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Queries
{
    public interface IEmployeeQueries
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int id);
    }
}
