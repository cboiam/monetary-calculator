using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Queries
{
    public interface IEmployeeQuery
    {
        Task<IEnumerable<Employee>> Get(CancellationToken cancellationToken = default);
        Task<Employee> Get(int id, CancellationToken cancellationToken = default);
    }
}
