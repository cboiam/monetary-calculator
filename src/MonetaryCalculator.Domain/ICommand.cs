namespace MonetaryCalculator.Domain
{
    public interface ICommand
    {
        bool IsValid();
    }
}
