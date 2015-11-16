namespace LaptopShops
{
    using System;

    class Program
    {
        static void Main()
        {
            Battery liLon = new Battery("Li-Ion, 4-cells, 2550 mAh", 5.0f);
            Battery niCd = new Battery("Ni-Cd", 4.5f);

            Laptop lenovo = new Laptop("Lenovo Yoga 2 Pro", (decimal)2259.00, "Lenovo", 
                "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8, 
                "128GB SSD", "Intel HD Graphics 4400", liLon, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");
            Laptop hp = new Laptop("HP 250 G2", (decimal)699.00);

            Console.WriteLine(lenovo);
            Console.WriteLine(hp);
        }
    }
}
