namespace TheaterSystem.Models
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatreName, string performanceName, DateTime startDate, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceName = performanceName;
            this.StartDate = startDate;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheatreName { get; private set; }

        public string PerformanceName { get; private set; }

        public DateTime StartDate { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; private set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int isEqual = this.StartDate.CompareTo(otherPerformance.StartDate);

            return isEqual;
        }

        public override string ToString()
        {
            string result = string.Format(
                "Performance(Tr32: {0}; Tr23: {1}; StartDate: {2}, Duration: {3}, Gia: {4})",
                this.TheatreName,
                this.PerformanceName,
                this.StartDate.ToString("dd.MM.yyyy HH:mm"), this.Duration.ToString("hh':'mm"), this.Price.ToString("f2"));

            return result;
        }
    }
}