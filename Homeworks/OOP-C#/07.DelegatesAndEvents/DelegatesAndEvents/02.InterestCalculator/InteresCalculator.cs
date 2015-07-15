using System;

namespace _02.InterestCalculator
{   
    class InteresCalculator
    {
        public InteresCalculator(decimal money, double interest, int years, Func<decimal, double, int, decimal> interestCalculation)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.TotalSum = interestCalculation(this.Money, this.Interest, this.Years);
        }

        public decimal Money { get; set; }
        public double Interest { get; set; }
        public int Years { get; set; }
        public decimal TotalSum { get; set; }

        public override string ToString()
        {
            string result = string.Format("Money: {0}\nInterest: {1}\nYears: {2}\nResult: {3:F4}",
                this.Money, this.Interest, this.Years, this.TotalSum);

            return result;
        }
    }
}
