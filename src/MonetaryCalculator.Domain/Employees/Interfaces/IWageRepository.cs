using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Interfaces
{
    public interface IWageRepository
    {
        Task<Wage> Create(int employeeId, Wage wage);
    }
}
