namespace Capitalism.Models
{
    public interface IPaidPerson : IPerson
    {
        decimal Salary { get; }
    }
}
