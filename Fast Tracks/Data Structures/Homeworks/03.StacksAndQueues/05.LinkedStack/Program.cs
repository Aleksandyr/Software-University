using System;

namespace _05.LinkedStack
{
    class Program
    {
        static void Main()
        {
            LinkedStack<int> linkedStack = new LinkedStack<int>();
            linkedStack.Push(1);
            linkedStack.Push(2);
            linkedStack.Push(3);

            //var first = linkedStack.Pop();
            //Console.WriteLine(first);

            var array = linkedStack.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
