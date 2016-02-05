using FactoryMethod;

namespace TankManufacturer
{
    using System;

    using TankManufacturer.Units;

    class Program
    {
        static void Main()
        {
            var tankFactory = new RussianTankFactory();

            var tank = tankFactory.CreateTank();

            Console.WriteLine(tank);
        }
    }
}
