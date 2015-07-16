using System;

namespace _07.LinkedQueue
{
    class Program
    {
        static void Main()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(3);

            //var firstElement = linkedQueue.Dequeue();
            //Console.WriteLine(firstElement);

            var arr = linkedQueue.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
