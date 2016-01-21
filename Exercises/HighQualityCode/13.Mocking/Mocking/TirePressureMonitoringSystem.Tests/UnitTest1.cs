using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TirePressureMonitoringSystem.Interfaces;

namespace TirePressureMonitoringSystem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private RandomNumberProvider rndNumProv;

        [TestInitialize]
        private void MethodInitialize()
        {
            Random rnd = new Random();
            this.rndNumProv = new RandomNumberProvider(rnd);
        }

        [TestMethod]
        public void asd()
        {
            //Arange
            var mock = new Mock<ISensor>();
            mock.Setup(r => r.PopNextPressurePsiValue())
                .Returns(1);

            Sensor sensor = new Sensor(this.rndNumProv);
            Alarm alarm = new Alarm(mock.Object);

            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
