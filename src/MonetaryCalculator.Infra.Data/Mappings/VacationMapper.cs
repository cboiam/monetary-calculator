using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Infra.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonetaryCalculator.Infra.Data.Mappings
{
    public class VacationMapper : IMapper<Vacation, VacationModel>,
        IMapper<VacationModel, Vacation>,
        IMapper<List<Vacation>, List<VacationModel>>,
        IMapper<List<VacationModel>, List<Vacation>>
    {
        public VacationModel Map(Vacation source)
        {
            if (source == null)
            {
                return null;
            };

            return new VacationModel
            {
                Id = source.Id,
                StartDate = source.StartDate,
                EndDate = source.EndDate
            };
        }

        public Vacation Map(VacationModel source)
        {
            if (source == null)
            {
                return null;
            };

            return new Vacation
            {
                Id = source.Id,
                StartDate = source.StartDate,
                EndDate = source.EndDate
            };
        }

        public List<VacationModel> Map(List<Vacation> source) => source.Select(Map).ToList();
        public List<Vacation> Map(List<VacationModel> source) => source.Select(Map).ToList();
    }
}
