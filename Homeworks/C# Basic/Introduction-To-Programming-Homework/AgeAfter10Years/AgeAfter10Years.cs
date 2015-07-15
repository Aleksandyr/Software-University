using System;


class AgeAfter10Years
{
    static void Main()
    {
        Console.Write("Enter your age in format dd/mm/yy: ");
        DateTime birthDay = new DateTime();
        birthDay = DateTime.Parse(Console.ReadLine());

        int yourAgeNow = DateTime.Now.Year - birthDay.Year;
        if (DateTime.Now.Month < birthDay.Month || DateTime.Now.Month == birthDay.Month && DateTime.Now.Day < birthDay.Day)
        {
            yourAgeNow--;
        }
        
        Console.WriteLine("Your age now is: " + yourAgeNow);

        int yourAgeAfter10Years = yourAgeNow + 10;
        Console.WriteLine("Your age after ten years will be: " + yourAgeAfter10Years);
    }
}

