namespace AnimalFarm
{
    using System;

    public class AnimalFarm
    {
        public static void Main()
        {
            Chicken chicken = new Chicken("Mara", 16);
            Console.WriteLine(chicken.ProductPerDay);
            Console.WriteLine(chicken.ProduceProduct());
        }
    }
}
