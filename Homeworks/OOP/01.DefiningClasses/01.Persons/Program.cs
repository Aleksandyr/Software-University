namespace Persons
{
    using System;

    class Program
    {
        static void Main()
        {
            Person pesho = new Person("pesho", 22);
            Console.WriteLine(pesho);

            Console.WriteLine("-------------------");

            Person misho = new Person("misho", 50, "misho@abv.bg");
            Console.WriteLine(misho);
        }
    }
}
