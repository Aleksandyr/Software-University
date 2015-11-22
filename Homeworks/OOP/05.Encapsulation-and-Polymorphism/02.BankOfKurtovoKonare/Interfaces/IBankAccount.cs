namespace BankOfKurtovoKonare.Interfaces
{
    using BankOfKurtovoKonare.Enums;

    public interface IBankAccount
    {
        Customer Customer { get; set; }

        decimal Balance { get; set; }

        decimal InterestRate { get; set; }

        decimal CalculateInterestForGivenMonth(int months);
    }
}
