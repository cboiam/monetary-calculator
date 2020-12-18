using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonetaryCalculator.Infra.Data.Mappings
{
    public class EmployeeMapper : IMapper<Employee, EmployeeModel>,
        IMapper<EmployeeModel, Employee>
    {
        private readonly IMapper<List<VacationModel>, List<Vacation>> vacationModelMapper;
        private readonly IMapper<List<WageModel>, List<Wage>> wageModelMapper;
        private readonly IMapper<List<Vacation>, List<VacationModel>> vacationEntityMapper;
        private readonly IMapper<List<Wage>, List<WageModel>> wageEntityMapper;

        public EmployeeMapper(IMapper<List<VacationModel>, List<Vacation>> vacationModelMapper,
            IMapper<List<WageModel>, List<Wage>> wageModelMapper,
            IMapper<List<Vacation>, List<VacationModel>> vacationEntityMapper, 
            IMapper<List<Wage>, List<WageModel>> wageEntityMapper)
        {
            this.vacationModelMapper = vacationModelMapper;
            this.wageModelMapper = wageModelMapper;
            this.vacationEntityMapper = vacationEntityMapper;
            this.wageEntityMapper = wageEntityMapper;
        }

        public Employee Map(EmployeeModel source)
        {
            if (source == null)
            {
                return null;
            };

            return new Employee
            {
                Id = source.Id,
                Name = source.Name,
                HiringDate = source.HiringDate,
                LeaveDate = source.LeaveDate,
                LeaveCondition = source.LeaveCondition,
                Vacations = source.Vacations != null ? vacationModelMapper.Map(source.Vacations.ToList()) : null,
                Wages = source.Wages != null ? wageModelMapper.Map(source.Wages?.ToList()) : null
            };
        }

        public EmployeeModel Map(Employee source)
        {
            if (source == null)
            {
                return null;
            };

            return new EmployeeModel
            {
                Id = source.Id,
                Name = source.Name,
                HiringDate = source.HiringDate,
                LeaveDate = source.LeaveDate,
                Dismissed = source.LeaveDate > DateTime.Today,
                LeaveCondition = source.LeaveCondition,
                Vacations = source.Vacations != null ? vacationEntityMapper.Map(source.Vacations.ToList()) : null,
                Wages = source.Wages != null ? wageEntityMapper.Map(source.Wages?.ToList()) : null
            };
        }
    }
}
