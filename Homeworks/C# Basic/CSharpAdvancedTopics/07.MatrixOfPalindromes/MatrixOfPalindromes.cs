using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cows; j++)
            {
                Console.Write((char)(97 + i));
                Console.Write((char)(97 + counter));
                Console.Write((char)(97 + i));
                Console.Write(" ");
                counter++;
            }
            Console.WriteLine();
            counter = i + 1;
        }
    }
}

