using MediatR;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class UpdateEmployeeNameCommand : ICommand, IRequest<bool>
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public bool IsValid()
        {
            return Id != default && !string.IsNullOrWhiteSpace(Name);
        }
    }
}
