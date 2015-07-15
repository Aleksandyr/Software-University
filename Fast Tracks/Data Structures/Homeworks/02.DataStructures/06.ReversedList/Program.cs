using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReversedList
{
    class Program
    {
        static void Main()
        {
            //Run and test

            ReversedList<int> rev = new ReversedList<int>();
            rev.Add(1);
            rev.Add(2);
            rev.Add(3);
            rev.Add(4);
          
            Console.WriteLine(rev);
            foreach (var i in rev)
            {
                Console.WriteLine(i);
            }

        }
    }
}
