namespace Customer
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            Customer Ivan = new Customer(3, "Ivan", "Petrov", "Goshov", "Sofia, Mladost", "+359-897-687-52", "ivan@gmail.com", CustomerType.Golden, new List<Payment>() { new Payment("Lenovo", 533), new Payment("Samsung", 789), });
            Customer Petar = new Customer(2, "Petar", "Goshov", "Ivanov", "Sofia, Lulin", "+359-897-534-59", "petar@gmail.com", CustomerType.OneTime, new List<Payment>() { new Payment("Acer", 533), new Payment("MSI", 789), });
            Customer Ivan4o = new Customer(1, "Ivan", "Petrov", "Goshov", "Sofia, Iztok", "+359-897-687-49", "ivan4o@gmail.com", CustomerType.Diamond, new List<Payment>() { new Payment("Asus", 533), new Payment("HP", 789), });
            Customer IvanCopy = (Customer)Ivan.Clone();

            Console.WriteLine(Ivan + "\n");

            Console.WriteLine(Ivan.Equals(Petar));
            Console.WriteLine(Ivan.Equals(Ivan4o));
            Console.WriteLine(Ivan.Equals(IvanCopy) + "\n");

            Console.WriteLine(Ivan.CompareTo(IvanCopy));
            Console.WriteLine(Ivan.CompareTo(Ivan4o));
        }
    }
}
