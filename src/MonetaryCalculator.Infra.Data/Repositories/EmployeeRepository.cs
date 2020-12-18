using Microsoft.EntityFrameworkCore;
using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Domain.Employees.Interfaces;
using MonetaryCalculator.Domain.Employees.Queries;
using MonetaryCalculator.Infra.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Infra.Data.Repositories
{
    public class EmployeeRepository : IEmployeeQuery, IEmployeeRepository
    {
        private readonly IRepository<EmployeeModel> repository;
        private readonly IMapper<Employee, EmployeeModel> modelMapper;
        private readonly IMapper<EmployeeModel, Employee> entityMapper;

        public EmployeeRepository(IRepository<EmployeeModel> repository,
            IMapper<Employee, EmployeeModel> modelMapper, 
            IMapper<EmployeeModel, Employee> entityMapper)
        {
            this.repository = repository;
            this.modelMapper = modelMapper;
            this.entityMapper = entityMapper;
        }

        public async Task<Employee> Create(Employee employee)
        {
            var result = await repository.Add(modelMapper.Map(employee));
            return entityMapper.Map(result);
        }

        public async Task<IEnumerable<Employee>> Get(CancellationToken cancellationToken = default)
        {
            var result = await repository.GetAll(cancellationToken);
            return result.Select(entityMapper.Map);
        }

        public async Task<Employee> Get(int id, CancellationToken cancellationToken = default)
        {
            var result = await repository.DbSet
                .AsNoTracking()
                .Include(e => e.Wages)
                .Include(e => e.Vacations)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return entityMapper.Map(result);
        }

        public async Task Update(Employee employee)
        {
            await repository.Update(modelMapper.Map(employee));
        }
    }
}
