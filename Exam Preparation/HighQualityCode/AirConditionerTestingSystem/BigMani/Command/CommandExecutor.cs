namespace BigMani.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BigMani.Core;
    using BigMani.Exceptions;
    using BigMani.Infrastructure;
    using BigMani.Interfaces;
    using BigMani.Models;

    public class CommandExecutor : ICommandExecutor
    {
        public CommandExecutor(IDatabase database)
        {
            this.Database = database;
        }

        public IDatabase Database { get; set; }

        public virtual string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            if (this.ValidateDuplicateAirConditionar(manufacturer, model))
            {
                throw new DuplicateEntryException(ValidationConstants.DUPLICATE);
            }

            AirConditionar airConditioner = new StationaryAirConditioners(manufacturer, model, energyEfficiencyRating, powerUsage);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(ValidationConstants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        public virtual string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            if (this.ValidateDuplicateAirConditionar(manufacturer, model))
            {
                throw new DuplicateEntryException(ValidationConstants.DUPLICATE);
            }

            AirConditionar airConditioner = new CarAirConditioners(manufacturer, model, volumeCoverage);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(ValidationConstants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        /// <summary>
        /// This mehtod put in database Plane air conditionar, 
        /// and check if the conditior manufacturer and model is duplicated
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="volumeCoverage"></param>
        /// <param name="electricityUsed"></param>
        /// <returns>string that say the conditionar is registered.</returns>
        public virtual string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsed)
        {
            if (this.ValidateDuplicateAirConditionar(manufacturer, model))
            {
                throw new DuplicateEntryException(ValidationConstants.DUPLICATE);
            }

            AirConditionar airConditioner = new PlaneAirConditioners(manufacturer, model, volumeCoverage, electricityUsed);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(ValidationConstants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        public virtual string TestAirConditioner(string manufacturer, string model)
        {
            if (this.ValidateDuplicateReports(manufacturer, model))
            {
                throw new DuplicateEntryException(ValidationConstants.DUPLICATE);
            }

            AirConditionar airConditioner = this.Database.GetAirConditioner(manufacturer, model);
            airConditioner.EnergyRating += 5;
            var mark = airConditioner.Test();
            this.Database.Reports.Add(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            return string.Format(ValidationConstants.TEST, model, manufacturer);
        }

        /// <summary>
        /// This method get form database air conditioner if he is exist.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <returns>return description for current conditioner.</returns>
        public virtual string FindAirConditioner(string manufacturer, string model)
        {
            AirConditionar airConditioner = this.Database.GetAirConditioner(manufacturer, model);
            return airConditioner.ToString();
        }

        public virtual string FindReport(string manufacturer, string model)
        {
            IReport report = this.Database.GetReport(manufacturer, model);
            return report.ToString();
        }

        public virtual string FindAllReportsByManufacturer(string manufacturer)
        {
            List<IReport> reports = this.Database.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return ValidationConstants.NOREPORTS;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }

        /// <summary>
        /// This method print how jobs is compleeted
        /// </summary>
        /// <returns>return string with porcentage of job execution</returns>
        public virtual string Status()
        {
            int reports = this.Database.GetReportsCount();
            double airConditioners = this.Database.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(ValidationConstants.STATUS, percent);
        }

        private bool ValidateDuplicateAirConditionar(string manufacturer, string model)
        {
            var isHaveModelWithSameManufaturer =
                this.Database.AirConditioners.Any(a => a.Manufacturer == manufacturer);
            var isHaveModelWithSameModel = this.Database.AirConditioners.Any(a => a.Model == model);

            if (isHaveModelWithSameModel && isHaveModelWithSameManufaturer)
            {
                return true;
            }

            return false;
        }

        private bool ValidateDuplicateReports(string manufacturer, string model)
        {
            var isHaveReportWithSameManufacturer =
                this.Database.Reports.Any(a => a.Manufacturer == manufacturer);
            var isHaveReportWithSameModel = this.Database.Reports.Any(a => a.Model == model);

            if (isHaveReportWithSameManufacturer && isHaveReportWithSameModel)
            {
                return true;
            }

            return false;
        }
    }
}
