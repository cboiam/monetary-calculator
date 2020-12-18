using MediatR;
using MonetaryCalculator.Domain.Employees.Commands;
using MonetaryCalculator.Domain.Employees.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MonetaryCalculator.Domain.Employees.Handlers
{
    public class RegisterVacationHandler : IRequestHandler<RegisterVacationCommand, Vacation>
    {
        private readonly IVacationRepository vacationRepository;

        public RegisterVacationHandler(IVacationRepository vacationRepository)
        {
            this.vacationRepository = vacationRepository;
        }

        public async Task<Vacation> Handle(RegisterVacationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                throw new BusinessException("Register vacation command is invalid");
            }

            var vacation = new Vacation
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            return await vacationRepository.Create(request.EmployeeId, vacation);
        }
    }
}
