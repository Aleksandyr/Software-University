namespace BigMani.Interfaces
{
    using System.Collections.Generic;

    using BigMani.Exceptions;
    using BigMani.Models;

    public interface IDatabase
    {
        ISet<AirConditionar> AirConditioners { get; }

        ISet<IReport> Reports { get; }

        void AddAirConditioner(AirConditionar airConditioner);

        void RemoveAirConditioner(AirConditionar airConditioner);

        AirConditionar GetAirConditioner(string manufacturer, string model);

        int GetAirConditionersCount();

        void AddReport(IReport report);

        void RemoveReport(IReport report);

        IReport GetReport(string manufacturer, string model);

        int GetReportsCount();

        List<IReport> GetReportsByManufacturer(string manufacturer);
    }
}
