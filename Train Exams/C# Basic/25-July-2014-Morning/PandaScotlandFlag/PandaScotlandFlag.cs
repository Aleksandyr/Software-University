using System;

class PandaScotlandFlag
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());

        char letter = 'A';
        Console.WriteLine(letter + "{0}" + GetNextLetter(letter), new string('#', n - 2));
        
        int tilde = 1;
        int dies = n - 4;
        letter = GetNextLetter(letter);
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write("{0}", new string('~', tilde));
            letter = GetNextLetter(letter);
            Console.Write(letter);
            Console.Write("{0}", new string('#', dies));
            letter = GetNextLetter(letter);
            Console.Write(letter);
            Console.Write("{0}", new string('~', tilde));
            tilde++;
            dies -= 2;
            Console.WriteLine();
        }

        Console.WriteLine("{0}" + GetNextLetter(letter) + "{0}", new string('-', n / 2));

        tilde = n / 2 - 1;
        dies = 1;
        letter = GetNextLetter(letter);
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write("{0}", new string('~', tilde));
            letter = GetNextLetter(letter);
            Console.Write(letter);
            Console.Write("{0}", new string('#', dies));
            letter = GetNextLetter(letter);
            Console.Write(letter);
            Console.Write("{0}", new string('~', tilde));
            tilde--;
            dies += 2;
            Console.WriteLine();            
        }

        letter = GetNextLetter(letter);
        Console.WriteLine(letter + "{0}" + GetNextLetter(letter), new string('#', n - 2));
    }

    static char GetNextLetter(char letter)
    {
        letter++;
        if (letter > 'Z')
        {
            letter = 'A';
        }

        return letter;
    }
}


