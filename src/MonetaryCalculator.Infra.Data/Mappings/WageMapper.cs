using MonetaryCalculator.Domain.Employees;
using MonetaryCalculator.Infra.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonetaryCalculator.Infra.Data.Mappings
{
    public class WageMapper : IMapper<Wage, WageModel>,
        IMapper<WageModel, Wage>,
        IMapper<List<Wage>, List<WageModel>>,
        IMapper<List<WageModel>, List<Wage>>
    {
        public List<WageModel> Map(List<Wage> source) => source.Select(Map).ToList();
        public List<Wage> Map(List<WageModel> source) => source.Select(Map).ToList();

        public Wage Map(WageModel source)
        {
            if (source == null)
            {
                return null;
            };

            return new Wage
            {
                Id = source.Id,
                CountUnit = source.CountUnit,
                Amount = source.Amount
            };
        }

        public WageModel Map(Wage source)
        {
            if (source == null)
            {
                return null;
            };

            return new WageModel
            {
                Id = source.Id,
                CountUnit = source.CountUnit,
                Amount = source.Amount
            };
        }
    }
}
