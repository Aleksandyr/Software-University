using System;
using System.Security;

namespace _03.ArrayStack
{
    class Program
    {
        static void Main()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
        

            //var last = stack.Pop();
            Console.WriteLine(stack.Count);
            //Console.WriteLine(last);

            var toArr = stack.ToArray();
            for (int i = 0; i < toArr.Length; i++)
            {
                Console.WriteLine(toArr[i]);
            }
        }
    }
}
