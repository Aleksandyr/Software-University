using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CalcSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            for (int i = 0; i <= 50; i++)
            {
                sequence.Enqueue(n + 1);
                sequence.Enqueue((n * 2) + 1);
                sequence.Enqueue(n + 2);
                
                n = sequence.ToArray()[i + 1];
            }

            Console.WriteLine(String.Join(", ", sequence));
        }
    }
}
