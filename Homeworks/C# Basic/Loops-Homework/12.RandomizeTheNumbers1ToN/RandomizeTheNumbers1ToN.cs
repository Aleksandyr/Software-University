using System;

class RandomizeTheNumbers1ToN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Random rnd = new Random();
        for (int i = 0; i <= n; i++)
        {
            Console.Write(rnd.Next(1, n + 1)+ " ");    
        }
        Console.WriteLine();
    }
}

