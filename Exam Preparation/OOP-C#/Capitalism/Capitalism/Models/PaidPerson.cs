namespace Capitalism.Models
{
    public abstract class PaidPerson : IPaidPerson
    {
        public string FirstName { get; }

        public string LastName { get; }

        public decimal Salary { get; }
    }
}
