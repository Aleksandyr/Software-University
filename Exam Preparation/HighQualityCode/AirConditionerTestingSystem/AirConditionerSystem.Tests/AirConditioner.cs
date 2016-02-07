using System;
using BigMani.Command;
using BigMani.Exceptions;
using BigMani.Infrastructure;

namespace AirConditionerSystem.Tests
{
    using BigMani.GoodStuff;
    using BigMani.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AirConditioner
    {
        private IDatabase db;
        private ICommandExecutor cmd;

        [TestInitialize]
        public void Initialize()
        {
            this.db = new Database();
            this.cmd = new CommandExecutor(db);
        }

        [TestMethod]
        public void TestReqisterStationaryAirConditionarShouldReturnSuccessfulReqister()
        {
            const string manufacturer = "Toshiba";
            const string model = "EX1000";

            var result = this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "B", 1000);

            var expectedResult = string.Format(ValidationConstants.REGISTER, "EX1000", "Toshiba");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestReqisterStationaryAirConditionarShouldHaveSameManufacturerAndModelFromDb()
        {
            const string manufacturer = "Toshiba";
            const string model = "EX1000";

            var result = this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "B", 1000);

            var airConditionar = this.db.GetAirConditioner(manufacturer, model);

            Assert.AreEqual(manufacturer, airConditionar.Manufacturer);
            Assert.AreEqual(model, airConditionar.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReqisterStationaryAirConditionarWithInvalidManufacturerSHouldThrow()
        {
            const string manufacturer = "Tos";
            const string model = "EX1000";

            var result = this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "B", 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReqisterStationaryAirConditionarWithInvalidModelSHouldThrow()
        {
            const string manufacturer = "Toshiba";
            const string model = "";

            var result = this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "B", 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReqisterStationaryAirConditionarWithInvalidEnergyRatingSHouldThrow()
        {
            const string manufacturer = "Toshiba";
            const string model = "EX1000";

            var result = this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "J", 1000);
        }

        [TestMethod]

        public void TestFindAllReportsByManufactureWithoutReportsShouldReturnNoReports()
        {
            const string manufacturer = "Toshiba";
            const string model = "EX1000";

            this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "B", 1000);

            var result = this.cmd.FindAllReportsByManufacturer(manufacturer);

            var expectedResult = ValidationConstants.NOREPORTS;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestFindAllReportsByManufactureReportedShouldGetThem()
        {
            const string manufacturer = "Toshiba";
            const string model = "EX1000";

            this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "B", 1000);
            this.cmd.TestAirConditioner(manufacturer, model);

            var report = this.cmd.FindAllReportsByManufacturer(manufacturer);
            var expectedResult =
                "Reports from Toshiba:\r\nReport\r\n====================\r\nManufacturer: Toshiba\r\nModel: EX1000\r\nMark: Passed\r\n====================";

            Assert.AreEqual(expectedResult, report);
        }

        [TestMethod]
        public void TestStatusActionWithCorrectReportsAndAirConditioners()
        {
            const string manufacturer = "Toshiba";
            const string model = "EX1000";

            this.cmd.RegisterStationaryAirConditioner(manufacturer, model, "B", 1000);
            this.cmd.RegisterStationaryAirConditioner(manufacturer + "1", model, "B", 1000);
            this.cmd.TestAirConditioner(manufacturer, model);

            var result = this.cmd.Status();
            var expectedResult = "Jobs complete: 50.00%";

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestStatusActionWithoutReportsAndAirConditionarShouldReturnNotANumber()
        {
            const string manufacturer = "Toshiba";
            const string model = "EX1000";

            var result = this.cmd.Status();
            var expectedResult = "Jobs complete: NaN%";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
