using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mini4ki
{
    public class Minesweeper
    {
        public class Rank
        {
            private string name;

            private int points;

            public string PlayerName
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public int Points
            {
                get
                {
                    return points;
                }

                set
                {
                    points = value;
                }
            }

            public Rank()
            {
            }

            public Rank(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        private static void Main(string[] args)
        {
            const byte MaxWinners = 6;
            const int MaxCells = 35;

            string command = string.Empty;
            char[,] field = CreatePlayground();
            char[,] bombs = PutTheBombs();
            int counter = 0;
            bool explosion = false;
            List<Rank> winners = new List<Rank>(MaxWinners);
            int row = 0;
            int coll = 0;
            bool flag = true;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Let's play 'Minichki' Try your luck to find fields without tread on mines."
                        + " \nCommand 'top' List the rating\nCommand 'restart' restart the game\nCommand 'exit' exit of the game!");
                    dumpp(field);
                    flag = false;
                }

                Console.Write("Write row and coll : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out coll)
                        && row <= field.GetLength(0) && coll <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GiveRating(winners);
                        break;
                    case "restart":
                        field = CreatePlayground();
                        bombs = PutTheBombs();
                        dumpp(field);
                        explosion = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye!");
                        break;
                    case "turn":
                        if (bombs[row, coll] != '*')
                        {
                            if (bombs[row, coll] == '-')
                            {
                                ChangeTurn(field, bombs, row, coll);
                                counter++;
                            }

                            if (MaxCells == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                dumpp(field);
                            }
                        }
                        else
                        {
                            explosion = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (explosion)
                {
                    dumpp(bombs);
                    Console.Write("\nYou died with {0} points. " + "Write your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Rank t = new Rank(nickname, counter);
                    if (winners.Count < 5)
                    {
                        winners.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < t.Points)
                            {
                                winners.Insert(i, t);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Rank r1, Rank r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    winners.Sort((Rank r1, Rank r2) => r2.Points.CompareTo(r1.Points));
                    GiveRating(winners);

                    field = CreatePlayground();
                    bombs = PutTheBombs();
                    counter = 0;
                    explosion = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nCongratulations you opened all {0} cells", MaxCells);
                    dumpp(bombs);
                    Console.WriteLine("Give me yor nickname: ");
                    string winnerName = Console.ReadLine();
                    Rank points = new Rank(winnerName, counter);
                    winners.Add(points);
                    GiveRating(winners);
                    field = CreatePlayground();
                    bombs = PutTheBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("I hope you've enjoyed!");
            Console.WriteLine("See you soon.");
            Console.Read();
        }

        private static void GiveRating(List<Rank> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} Cells", i + 1, points[i].PlayerName, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rating!\n");
            }
        }

        private static void ChangeTurn(char[,] field, char[,] bombs, int row, int coll)
        {
            char numberOfBombs = CountBombs(bombs, row, coll);
            bombs[row, coll] = numberOfBombs;
            field[row, coll] = numberOfBombs;
        }

        private static void dumpp(char[,] board)
        {
            int boardRow = board.GetLength(0);
            int boardColl = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRow; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColl; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayground()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutTheBombs()
        {
            int row = 5;
            int coll = 10;
            char[,] playground = new char[row, coll];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < coll; j++)
                {
                    playground[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int newBomb = random.Next(50);
                //Check if current bumb already exist there
                if (!bombs.Contains(newBomb))
                {
                    bombs.Add(newBomb);
                }
            }

            foreach (int bomb in bombs)
            {
                int bombColl = bomb / coll;
                int bombRow = bomb % coll;
                if (bombRow == 0 && bomb != 0)
                {
                    bombColl--;
                    bombRow = bombColl;
                }
                else
                {
                    bombRow++;
                }

                playground[bombColl, bombRow - 1] = '*';
            }

            return playground;
        }

        private static void Calculates(char[,] field)
        {
            int coll = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < coll; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char count = CountBombs(field, i, j);
                        field[i, j] = count;
                    }
                }
            }
        }

        private static char CountBombs(char[,] bombs, int currRow, int currColl)
        {
            int counter = 0;
            int rows = bombs.GetLength(0);
            int colls = bombs.GetLength(1);

            if (currRow - 1 >= 0)
            {
                if (bombs[currRow - 1, currColl] == '*')
                {
                    counter++;
                }
            }

            if (currRow + 1 < rows)
            {
                if (bombs[currRow + 1, currColl] == '*')
                {
                    counter++;
                }
            }

            if (currColl - 1 >= 0)
            {
                if (bombs[currRow, currColl - 1] == '*')
                {
                    counter++;
                }
            }

            if (currColl + 1 < colls)
            {
                if (bombs[currRow, currColl + 1] == '*')
                {
                    counter++;
                }
            }

            if ((currRow - 1 >= 0) && (currColl - 1 >= 0))
            {
                if (bombs[currRow - 1, currColl - 1] == '*')
                {
                    counter++;
                }
            }

            if ((currRow - 1 >= 0) && (currColl + 1 < colls))
            {
                if (bombs[currRow - 1, currColl + 1] == '*')
                {
                    counter++;
                }
            }

            if ((currRow + 1 < rows) && (currColl - 1 >= 0))
            {
                if (bombs[currRow + 1, currColl - 1] == '*')
                {
                    counter++;
                }
            }

            if ((currRow + 1 < rows) && (currColl + 1 < colls))
            {
                if (bombs[currRow + 1, currColl + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}