using System;

namespace _03.GenericList
{
    class Program
    {
        static void Main()
        {
            GenericList<int> genericList = new GenericList<int>();
            genericList.Add(1);
            genericList.Add(2);
            genericList.Add(3);
            genericList.Add(3);
            genericList.Add(3);
            genericList.Remove(2);
            genericList.Remove(2);
            genericList.Insert(7, 1);
            genericList.Add(18);
            Console.WriteLine(genericList[4]);
            Console.WriteLine(genericList.Count);



            Console.WriteLine(genericList);
        }
    }
}
