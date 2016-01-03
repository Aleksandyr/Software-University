using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArr = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondArr = new double[,] { { 4, 2 }, { 1, 5 } };
            var result = MultTwoMatrix(firstArr, secondArr);

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] MultTwoMatrix(double[,] firstArr, double[,] secondArr)
        {
            if (firstArr.GetLength(1) != secondArr.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var lengthOfFirstArr = firstArr.GetLength(1);
            var newArr = new double[firstArr.GetLength(0), secondArr.GetLength(1)];
            for (int i = 0; i < newArr.GetLength(0); i++)
                for (int j = 0; j < newArr.GetLength(1); j++)
                    for (int k = 0; k < lengthOfFirstArr; k++)
                        newArr[i, j] += firstArr[i, k] * secondArr[k, j];
            return newArr;
        }
    }
}