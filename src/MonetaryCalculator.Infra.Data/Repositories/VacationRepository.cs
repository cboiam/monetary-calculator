using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Domain.Employees.Interfaces;
using MonetaryCalculator.Infra.Data.Models;
using System.Threading.Tasks;

namespace MonetaryCalculator.Infra.Data.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        private readonly IRepository<VacationModel> repository;
        private readonly IMapper<Vacation, VacationModel> modelMapper;
        private readonly IMapper<VacationModel, Vacation> entityMapper;

        public VacationRepository(IRepository<VacationModel> repository, 
            IMapper<Vacation, VacationModel> modelMapper, 
            IMapper<VacationModel, Vacation> entityMapper)
        {
            this.repository = repository;
            this.modelMapper = modelMapper;
            this.entityMapper = entityMapper;
        }

        public async Task<Vacation> Create(int employeeId, Vacation Vacation)
        {
            var VacationModel = modelMapper.Map(Vacation);
            VacationModel.EmployeeId = employeeId;

            var result = await repository.Add(VacationModel);
            return entityMapper.Map(result);
        }
    }
}
