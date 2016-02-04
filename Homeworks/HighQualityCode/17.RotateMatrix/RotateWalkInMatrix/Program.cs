using System;

public class RotatingWalkInMatrix
{
    public static void Main()
    {
        int n = ReadNumber();

        int[,] matrix = GenerateWalkingMatrix(n);

        PrintMatrix(matrix);
    }

    private static int ReadNumber()
    {
        string input = Console.ReadLine();
        int number;

        while (!int.TryParse(input, out number) || number < 0 || number > 100)
        {
            input = Console.ReadLine();
        }

        return number;
    }

    public static int[,] GenerateWalkingMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        int currentValue = 1;

        int row = 0;
        int col = 0;

        GenerateMatrix(n, matrix, row, col, ref currentValue);
        FindAvailableCell(matrix, out row, out col);

        if (row != 0 && col != 0)
        {
            GenerateMatrix(n, matrix, row, col, ref currentValue);
        }

        return matrix;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int matrixLength = matrix.GetLength(0);

        for (int row = 0; row < matrixLength; row++)
        {
            for (int col = 0; col < matrixLength; col++)
            {
                if (col == 0)
                {
                    Console.Write("{0}", matrix[row, col]);
                    continue;
                }

                Console.Write("{0,4}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static void GenerateMatrix(int n, int[,] matrix, int row, int col, ref int value)
    {
        int directionX = 1;
        int directionY = 1;

        while (true)
        {
            matrix[row, col] = value;

            if (!IsCellAvailable(matrix, row, col))
            {
                break;
            }

            while (row + directionX >= n ||
                row + directionX < 0 ||
                col + directionY >= n ||
                col + directionY < 0 ||
                matrix[row + directionX, col + directionY] != 0)
            {
                ChangeCurrentCoordinates(ref directionX, ref directionY);
            }

            row += directionX;
            col += directionY;
            value++;
        }

        value++;
    }
    private static void ChangeCurrentCoordinates(ref int currentX, ref int currentY)
    {
        int[] directionsOfX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsOfY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int directionsLength = directionsOfX.Length;
        int currentDirectionIndex = 0;

        for (int i = 0; i < directionsLength; i++)
        {
            if (directionsOfX[i] == currentX && directionsOfY[i] == currentY)
            {
                currentDirectionIndex = i;
                break;
            }
        }

        if (currentDirectionIndex == directionsLength - 1)
        {
            currentX = directionsOfX[0];
            currentY = directionsOfY[0];
            return;
        }

        currentX = directionsOfX[currentDirectionIndex + 1];
        currentY = directionsOfY[currentDirectionIndex + 1];
    }

    private static bool IsCellAvailable(int[,] matrix, int x, int y)
    {
        int[] directionsOfX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsOfY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int directionsLength = directionsOfX.Length;
        int matrixLength = matrix.GetLength(0);

        for (int i = 0; i < directionsLength; i++)
        {
            if (x + directionsOfX[i] >= matrixLength || x + directionsOfX[i] < 0)
            {
                directionsOfX[i] = 0;
            }

            if (y + directionsOfY[i] >= matrixLength || y + directionsOfY[i] < 0)
            {
                directionsOfY[i] = 0;
            }
        }

        for (int i = 0; i < directionsLength; i++)
        {
            if (matrix[x + directionsOfX[i], y + directionsOfY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    private static void FindAvailableCell(int[,] matrix, out int x, out int y)
    {
        int matrixLength = matrix.GetLength(0);
        x = 0;
        y = 0;

        for (int row = 0; row < matrixLength; row++)
        {
            for (int col = 0; col < matrixLength; col++)
            {
                if (matrix[row, col] == 0)
                {
                    x = row;
                    y = col;
                    return;
                }
            }
        }
    }
}