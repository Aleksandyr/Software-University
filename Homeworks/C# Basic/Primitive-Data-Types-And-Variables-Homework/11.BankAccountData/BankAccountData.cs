using System;

class BankAccountData
{
    static void Main()
    {
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Middle name: ");
        string middleName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());
        Console.Write("Bank name: ");
        string bankName = Console.ReadLine();
        Console.Write("IBAN: ");
        string iban = Console.ReadLine();
        Console.Write("First credit card number: ");
        ulong firstCardNumber = ulong.Parse(Console.ReadLine());
        Console.Write("Second credit card number: ");
        ulong secondCardNumber = ulong.Parse(Console.ReadLine());
        Console.Write("Third credit card number: ");
        ulong thirdCardNumber = ulong.Parse(Console.ReadLine());
       
    }
}

