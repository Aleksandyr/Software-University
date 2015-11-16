using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("pesho", 22);
            Console.WriteLine(pesho);

            Console.WriteLine("-------------------");

            Person misho = new Person("misho", 50, "misho@abv.bg");
            Console.WriteLine(misho);
        }
    }
}
