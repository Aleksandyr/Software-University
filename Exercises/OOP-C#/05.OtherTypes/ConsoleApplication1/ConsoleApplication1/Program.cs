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
            CustomList<int> elem = new CustomList<int>();
            elem.Add(7);
            elem.Add(10);
            elem.Add(7);
            elem.Add(777);
            elem.Add(22);
            elem.Add(155);
            //elem[4] = 1;

            elem.Remove(7);
            elem[4] = 1;
            Console.WriteLine(elem);
            Console.WriteLine(elem.Count);
            Console.WriteLine(elem.IndexOf(777));
        }
    }
}
