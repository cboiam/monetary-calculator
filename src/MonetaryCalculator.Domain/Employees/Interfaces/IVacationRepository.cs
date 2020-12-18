using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Interfaces
{
    public interface IVacationRepository
    {
        Task<Vacation> Create(int employeeId, Vacation vacation);
    }
}
