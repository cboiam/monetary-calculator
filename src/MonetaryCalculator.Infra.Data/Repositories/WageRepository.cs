using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Domain.Employees.Interfaces;
using MonetaryCalculator.Infra.Data.Models;
using System.Threading.Tasks;

namespace MonetaryCalculator.Infra.Data.Repositories
{
    public class WageRepository : IWageRepository
    {
        private readonly IRepository<WageModel> repository;
        private readonly IMapper<Wage, WageModel> modelMapper;
        private readonly IMapper<WageModel, Wage> entityMapper;

        public WageRepository(IRepository<WageModel> repository, 
            IMapper<Wage, WageModel> modelMapper, 
            IMapper<WageModel, Wage> entityMapper)
        {
            this.repository = repository;
            this.modelMapper = modelMapper;
            this.entityMapper = entityMapper;
        }

        public async Task<Wage> Create(int employeeId, Wage wage)
        {
            var wageModel = modelMapper.Map(wage);
            wageModel.EmployeeId = employeeId;

            var result = await repository.Add(wageModel);
            return entityMapper.Map(result);
        }
    }
}
