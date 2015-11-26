namespace InterestCalculator
{
    public class InterestCalculator
    {
        public InterestCalculator(int sum, double interest, int years, PerformCalculation calc)
        {
            this.Sum = calc(sum, interest, years);
        }

        public double Sum { get; set; }

        public override string ToString()
        {
            return this.Sum.ToString("F4");
        }
    }
}
