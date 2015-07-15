using System;
using LaptopInfo;
using BatteryInfo;

namespace LaptopShop
{
    class Program
    {
        static void Main()
        {
            Battery htx = new Battery("asd", 234);
            Laptop lenovo = new Laptop("lenovo Yoga 2 Pro", 123, 234, 6, htx, "Intel Graphics 44000", "1024 full HD",
                "Lion 4 cell", "asd");
            //Laptop lenovo = new Laptop("lenovo Yoga 2 Pro", 1200);
            Console.WriteLine(lenovo);
        }
    }
}
