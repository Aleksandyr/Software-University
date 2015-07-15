using System;

class EmployeeData
{
    static void Main()
    {
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Age: ");
        byte age = byte.Parse(Console.ReadLine());
        Console.Write("Gender: ");
        char gender = char.Parse(Console.ReadLine());
        Console.Write("Personal ID number: ");
        long persinalId = long.Parse(Console.ReadLine());
        Console.Write("Unique employee number should be between (27560000…27569999): ");
        int uniqueEmoloyeeNumber = int.Parse(Console.ReadLine());
       
        Console.WriteLine();
        Console.WriteLine("Print the employee information");
        Console.WriteLine();

        if (gender == 'm' || gender == 'M')
        {
            Console.WriteLine("His full name is: {0} {1}", firstName, lastName);
            Console.WriteLine("He is {0} years old", age);
            Console.WriteLine("His personal ID is: {0}", persinalId);
            Console.WriteLine("His unique employee number is: {0}", uniqueEmoloyeeNumber);
        }
        else
        {
            Console.WriteLine("Her full name is: {0} {1}", firstName, lastName);
            Console.WriteLine("She is {0} years old", age);
            Console.WriteLine("Her personal ID is: {0}", persinalId);
            Console.WriteLine("Her unique employee number is: {0}", uniqueEmoloyeeNumber);
        }
    }
}

