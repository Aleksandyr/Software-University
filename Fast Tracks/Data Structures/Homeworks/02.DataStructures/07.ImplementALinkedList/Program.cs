using System;
using System.Collections.Generic;
namespace _07.ImplementALinkedList
{
    class Program
    {
        static void Main()
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
 
            linkedList.Remove(2);
            linkedList.Add(4);
            linkedList.Add(4);
            linkedList.Add(4);

            //linkedList.Remove(0);
            Console.WriteLine(linkedList.FirstIndexOf(7));
            Console.WriteLine(linkedList.LastIndexOf(7));
            foreach (var i in linkedList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
