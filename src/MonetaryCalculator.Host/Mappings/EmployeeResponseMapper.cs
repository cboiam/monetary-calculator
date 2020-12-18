using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Host.Responses;
using MonetaryCalculator.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace MonetaryCalculator.Host.Mappings
{
    public class EmployeeResponseMapper : IMapper<IEnumerable<Employee>, IEnumerable<EmployeeResumedResponse>>,
        IMapper<Employee, EmployeeDetailedResponse>
    {
        public IEnumerable<EmployeeResumedResponse> Map(IEnumerable<Employee> source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Select(s => new EmployeeResumedResponse
            {
                Id = s.Id,
                Name = s.Name,
                HiringDate = s.HiringDate,
                LeaveDate = s.LeaveDate
            });
        }

        public EmployeeDetailedResponse Map(Employee source)
        {
            if (source == null)
            {
                return null;
            }

            return new EmployeeDetailedResponse
            {
                Id = source.Id,
                Name = source.Name,
                HiringDate = source.HiringDate,
                LeaveDate = source.LeaveDate,
                LeaveCondition = source.LeaveCondition,
                Wages = source.Wages,
                Vacations = source.Vacations
            };
        }
    }
}
