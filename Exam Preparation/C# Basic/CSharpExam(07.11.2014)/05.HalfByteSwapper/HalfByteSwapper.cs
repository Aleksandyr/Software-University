using System;
using System.Linq;

class HalfByteSwapper
{
    static void Main()
    {
        string[] board = new string[4];
        string[] position = new string[4];
        for (int i = 0; i < 4; i++)
        {
            int number = int.Parse(Console.ReadLine());
            board[i] = Convert.ToString(number, 2).PadLeft(32, '0');
        }

        for (int i = 0; i < 4; i++)
	    {
			string input = Console.ReadLine();
            //position[i] = input.Split(' ');

		}

        for (int i = 0; i < board.Length; i++)
        {
            //string firstFourth = board[i + p].Substring(j, 4);
            //string secondFourth = board[i + ]
        }
    }
}

