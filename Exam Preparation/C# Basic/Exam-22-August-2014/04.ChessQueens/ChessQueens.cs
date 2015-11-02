using System;

class ChessQueens
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());

        string[,] board = new string[size, size];
        bool isHaveAQueens = false;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                board[row, col] = "" + (char)('a' + row) + (col + 1);
            }
        }

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (row + distance + 1 < size)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[row + distance + 1, col]);
                    Console.WriteLine("{1} - {0}", board[row, col], board[row + distance + 1, col]);
                    isHaveAQueens = true;
                }

                if (col + distance + 1 < size)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[row, col + distance + 1]);
                    Console.WriteLine("{1} - {0}", board[row, col], board[row, col + distance + 1]);
                    isHaveAQueens = true;
                }

                if (row + distance + 1 < size && col + distance + 1 < size)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[row + distance + 1, col + distance + 1]);
                    Console.WriteLine("{1} - {0}", board[row, col], board[row + distance + 1, col + distance + 1]);
                    isHaveAQueens = true;
                }

                if (row + distance + 1 < size && col - distance - 1 >= 0)
                {
                    Console.WriteLine("{0} - {1}", board[row, col], board[row + distance + 1, col - distance - 1]);
                    Console.WriteLine("{1} - {0}", board[row, col], board[row + distance + 1, col - distance - 1]);
                    isHaveAQueens = true;
                }
            }
        }
        if (!isHaveAQueens)
        {
            Console.WriteLine("No valid positions");
        }
    }
}

