using System;

class MatrixOfNumber
{
    static void Main()
    {
        int n = 20;

        int counter = 1;
        for (int i = 0; i < n; i++)
        {
            counter = i + 1;
            for (int j = 0; j < n; j++)
            {
                Console.Write(counter);
                counter++;
            }
            Console.WriteLine();
        }
    }
}

