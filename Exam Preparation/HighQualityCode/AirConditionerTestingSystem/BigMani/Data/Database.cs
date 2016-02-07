namespace BigMani.GoodStuff
{
    using System.Collections.Generic;
    using System.Linq;

    using BigMani.Exceptions;
    using BigMani.Infrastructure;
    using BigMani.Interfaces;

    public class Database : IDatabase
    {
        public Database()
        {
            this.AirConditioners = new HashSet<AirConditionar>();
            this.Reports = new HashSet<IReport>();
        }

        public ISet<AirConditionar> AirConditioners { get;  private set; }

        public ISet<IReport> Reports { get; private set; }

        public void AddAirConditioner(AirConditionar airConditioner)
        {
            this.AirConditioners.Add(airConditioner);
        }

        public void RemoveAirConditioner(AirConditionar airConditioner)
        {
            this.AirConditioners.Remove(airConditioner);
        }

        public AirConditionar GetAirConditioner(string manufacturer, string model)
        {
            var airConditionar = this.AirConditioners.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (airConditionar == null)
            {
                throw new NonExistantEntryException(ValidationConstants.NONEXIST);
            }

            return airConditionar;
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditioners.Count;
        }

        public void AddReport(IReport report)
        {
            this.Reports.Add(report);
        }

        public void RemoveReport(IReport report)
        {
            this.Reports.Remove(report);
        }

        public IReport GetReport(string manufacturer, string model)
        {
            var report = this.Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (report == null)
            {
                throw new NonExistantEntryException(ValidationConstants.NONEXIST);    
            }

            return report;
        }

        public int GetReportsCount()
        {
            return this.Reports.Count;
        }

        public List<IReport> GetReportsByManufacturer(string manufacturer)
        {
            return this.Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
