using System;
using Moq;

namespace DateTimeNowAddDays.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDateTimeNowAddDays
    {
        [TestMethod]
        public void AddDayToTheMiddleOfTheMonthShouldWorkCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 07, 16));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expectedResult = new DateTime(2015, 07, 17);

            Assert.AreEqual(expectedResult, date);
        }

        [TestMethod]
        public void AddDayWhichWillBeInTheNextMonthShouldWorkCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 07, 31));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expectedResult = new DateTime(2015, 08, 01);

            Assert.AreEqual(expectedResult, date);
        }

        [TestMethod]
        public void AddNegativeValueForCurrentDateShouldReturnTheDateBack()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 07, 16));

            var date = mock.Object.DateTimeNow.AddDays(-5);
            var expectedResult = new DateTime(2015, 07, 11);

            Assert.AreEqual(expectedResult, date);
        }

        [TestMethod]
        public void AddDayToALepdYearShouldWorkCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2008, 02, 28));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expectedResult = new DateTime(2008, 02, 29);

            Assert.AreEqual(expectedResult, date);
        }

        [TestMethod]
        public void AddDayToANonLepdYearShouldWorkCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(1990, 02, 28));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expectedResult = new DateTime(1990, 03, 01);

            Assert.AreEqual(expectedResult, date);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddDayToDateTimeMaxValueShouldThrow()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MaxValue);

            mock.Object.DateTimeNow.AddDays(1);
        }

        [TestMethod]
        public void AddDayToDateTimeMinValueShouldWorkCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MinValue);

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expectedResult = new DateTime(0001, 01, 02);

            Assert.AreEqual(expectedResult, date);
        }

        [TestMethod]
        public void SubtractDayToDateTimeMaxValueShouldWorkCorreclty()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MaxValue);

            var date = mock.Object.DateTimeNow.AddDays(-1);
            var expectedResult = DateTime.MaxValue.AddDays(-1);

            Assert.AreEqual(expectedResult, date);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubtractDayToDateTimeMinValueShouldThrow()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MinValue);

            mock.Object.DateTimeNow.AddDays(-1);
        }
    }
}
