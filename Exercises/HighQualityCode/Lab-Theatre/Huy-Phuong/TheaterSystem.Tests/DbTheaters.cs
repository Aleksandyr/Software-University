using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheaterSystem.Data;
using TheaterSystem.Exceptions;

namespace TheaterSystem.Tests
{
    [TestClass]
    public class DbTheaters
    {
        private IPerformanceDatabase db;

        [TestInitialize]
        public void InitializeDb()
        {
            this.db = new TheatreDatabase();

           
        }

        [TestMethod]
        public void TestListTheatersWhenEmptyShouldHaveNoTheaters()
        {
            var theaters = this.db.ListTheatres();

            Assert.AreEqual(0, theaters.Count());
        }
        
        [TestMethod]

        public void TestListTheatersAddOneTheaterShouldHaveOneTheaters()
        {
            var theaters = this.db.ListTheatres();
            this.db.AddTheatre("Theatre Sofia");

            Assert.AreEqual(1, theaters.Count());
        }

        [TestMethod]

        public void TestListTheatersAddHundredTheaterShouldHaveHundredTheaters()
        {
            const int theatersCount = 100;
            var theaters = this.db.ListTheatres();
            for (int i = 0; i < theatersCount; i++)
            {

                this.db.AddTheatre("Theatre Sofia " + i);
            }

            Assert.AreEqual(theatersCount, theaters.Count());
        }

        [TestMethod]
        public void ListAllTheaterSortedByName()
        {
            this.db.AddTheatre("Theatre Sofia");
            this.db.AddTheatre("Theater 199");
            this.db.AddTheatre("Theater Asenovo");

            List<string> theaterNames = new List<string>()
            {
                "Theatre Sofia",
                "Theater 199",
                "Theater Asenovo"
            };

            theaterNames.Sort();
            var theatersFromDb = this.db.ListTheatres().ToList();

            for (int i = 0; i < theaterNames.Count; i++)
            {
                Assert.AreEqual(theaterNames[i], theatersFromDb[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException))]
        public void TestAddTheaterWithAddingSameTheaterShouldThrow()
        {
            this.db.AddTheatre("Theatre Sofia");
            this.db.AddTheatre("Theatre Sofia");
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ListAllTheaterUnsortedShouldThrow()
        {
            this.db.AddTheatre("Theatre Sofia");
            this.db.AddTheatre("Theater 199");
            this.db.AddTheatre("Theater Asenovo");

            List<string> theaterNames = new List<string>()
            {
                "Theatre Sofia",
                "Theater 199",
                "Theater Asenovo"
            };

            // theaterNames.Sort();
            var theatersFromDb = this.db.ListTheatres().ToList();

            for (int i = 0; i < theaterNames.Count; i++)
            {
                Assert.AreEqual(theaterNames[i], theatersFromDb[i]);
            }
        }
    }
}
