using System;
using System.Collections.Generic;
using System.Linq;
using TheaterSystem.Exceptions;
using TheaterSystem.Models;

namespace TheaterSystem.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheaterSystem.Data;

    [TestClass]
    public class DbPerformance
    {
        private IPerformanceDatabase db;

        [TestInitialize]
        public void InitializeDb()
        {
            this.db = new TheatreDatabase();
        }

        [TestMethod]
        public void AddPerformanceShouldAddedCorrectly()
        {
            const string TheaterName = "Theater Sofia";
            const string PerformanceName = "Duende";
            DateTime startDate = DateTime.ParseExact("20.01.2015 20:00", "dd.MM.yyyy HH:mm",
                System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:30");
            const decimal Price = 14.5M; 

            this.db.AddTheatre(TheaterName);
            this.db.AddPerformance(TheaterName, PerformanceName, startDate, duration, Price);

            var performancesFromCurrentTheater = this.db.ListPerformances(TheaterName).ToList();
            var currentPerformance = performancesFromCurrentTheater.Any(p => p.PerformanceName == PerformanceName);

            Assert.IsTrue(currentPerformance);
            Assert.AreEqual(1, performancesFromCurrentTheater.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void AddPerformanceToNonExistantTheaterShouldThrow()
        {
           const string TheaterName = "Theater Sofia";
            const string PerformanceName = "Duende";
            DateTime startDate = DateTime.ParseExact("20.01.2015 20:00", "dd.MM.yyyy HH:mm",
                System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:30");
            const decimal Price = 14.5M;

            this.db.AddPerformance(TheaterName, PerformanceName, startDate, duration, Price);
        }

        [TestMethod]
        public void TestAddPerformanceWithTenWhenExistingTheaterShoudAddTen()
        {
            const string TheatreName = "Some theatre";
            this.db.AddTheatre(TheatreName);
            const int TestNum = 10;
            for (int i = 0; i < TestNum; i++)
            {
                this.db.AddPerformance(TheatreName, "title" + i, new DateTime(2000, 01, i + 1), new TimeSpan(0, 0, 10), 40m);
            }

            var performances = this.db.ListPerformances(TheatreName);
            Assert.AreEqual(TestNum, performances.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void AddPerformanceWithSameDateShouldThrow()
        {
            const string TheaterName = "Theater Sofia";
            const string PerformanceName = "Duende";
            DateTime startDate = DateTime.Now;
            TimeSpan duration = TimeSpan.Parse("1:00");
            const decimal Price = 14.5M;

            this.db.AddTheatre(TheaterName);
            this.db.AddPerformance(TheaterName, PerformanceName, startDate, duration, Price);
            this.db.AddPerformance(TheaterName, PerformanceName + "name", startDate, duration, Price);
        }

        [TestMethod]
        public void TestAddPerformanceWhenNoneShouldReturnEmptyPerformances()
        {
            const string TheatreName = "Theater Sofia";
            this.db.AddTheatre(TheatreName);
            var performances = this.db.ListPerformances(TheatreName);

            Assert.AreEqual(0, performances.Count());
        }

        [TestMethod]
        public void ListPerformancesForValidTheaterShouldListThemSorted()
        {
            const string TheaterName = "Theater Sofia";
            const string FirstPerformanceName = "Auende";
            DateTime FirstStartDate = DateTime.ParseExact("20.01.2015 18:00", "dd.MM.yyyy HH:mm",
                System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan FirstDuration = TimeSpan.Parse("1:30");
            const decimal FirstPrice = 14.5M;

            const string secondPerformanceName = "Duende";
            DateTime secondstartDate = DateTime.ParseExact("20.01.2015 20:00", "dd.MM.yyyy HH:mm",
                System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan secondduration = TimeSpan.Parse("1:30");
            const decimal secondPrice = 14.5M;

            this.db.AddTheatre(TheaterName);
            this.db.AddPerformance(TheaterName, secondPerformanceName, secondstartDate, secondduration, FirstPrice);
            this.db.AddPerformance(TheaterName, FirstPerformanceName, FirstStartDate, FirstDuration, secondPrice);

            List<string> namesOfSortedPerformanceNames = new List<string>();
            namesOfSortedPerformanceNames.Add(FirstPerformanceName);
            namesOfSortedPerformanceNames.Add(secondPerformanceName);
            namesOfSortedPerformanceNames.Sort();

            //var performancesToCurrentTheater = this.db.ListPerformances(TheaterName).ToList();
            var listPerformances = this.db.ListPerformances(TheaterName).ToList();

            for (int i = 0; i < namesOfSortedPerformanceNames.Count; i++)
            {
                Assert.AreEqual(namesOfSortedPerformanceNames[i], listPerformances[i].PerformanceName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void ListPerformanceForInvalidTheaterShouldThrow()
        {
            const string invalidTheaterName = "Invalid Name";

            const string TheaterName = "Theater Sofia";
            const string PerformanceName = "Duende";
            DateTime startDate = DateTime.ParseExact("20.01.2015 20:00", "dd.MM.yyyy HH:mm",
                System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse("1:30");
            const decimal Price = 14.5M;

            this.db.AddTheatre(TheaterName);
            this.db.AddPerformance(TheaterName, PerformanceName, startDate, duration, Price);

            var performancesToCurrentTheater = this.db.ListPerformances(invalidTheaterName).ToList();
        }
    }
}
