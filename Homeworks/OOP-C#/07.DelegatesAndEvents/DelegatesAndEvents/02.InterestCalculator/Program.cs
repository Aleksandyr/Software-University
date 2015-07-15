using System;

namespace _02.InterestCalculator
{
    class Program
    {
        static void Main()
        {
            Func<decimal, double, int, decimal> simple = GetSimpleInterest;
            Func<decimal, double, int, decimal> compound = GetCompoundtInterest;

            var acc1 = new InteresCalculator(500, 5.6, 10, compound);
            var acc2 = new InteresCalculator(2500, 7.2, 15, simple);

            Console.WriteLine(acc1);
            Console.WriteLine(acc2);
        }

        public static decimal GetSimpleInterest(decimal sum, double interest, int years)
        {
            decimal res = sum * (1 + ((decimal)interest / 100 * years));
            return res;
        }

        public static decimal GetCompoundtInterest(decimal sum, double interest, int years)
        {
            decimal result = sum * (decimal)Math.Pow((double)(1 + (interest / 100 / 12)), years * 12);
            return result;
        }
    }
}
