using System;
namespace InterestCalculator
{
    public delegate double PerformCalculation(int sum, double interest, int year);
    public class Program
    {
        static void Main()
        {
            PerformCalculation simpleInterestCalc = Interest.GetSimpleInterest;
            PerformCalculation complexInterestCalc = Interest.GetCompoundInterest;

            var simpleInterest = new InterestCalculator(2500, 0.072, 15, simpleInterestCalc);
            var complexInterest = new InterestCalculator(500, 0.056, 10, complexInterestCalc);
            
            Console.WriteLine(simpleInterest);
            Console.WriteLine(complexInterest);
        }
    }

    public static class Interest
    {
        public static double GetSimpleInterest(int sum, double interest, int years)
        {
            return sum * (1 + interest * years);
        }

        public static double GetCompoundInterest(int sum, double interest, int years)
        {
            var n = 12;
            return sum * Math.Pow((1 + interest / n), years * n);
        }

    }
}
