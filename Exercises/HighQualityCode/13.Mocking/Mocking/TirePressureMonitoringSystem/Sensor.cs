using System;
using TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Sensor : ISensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //

        const double Offset = 16;
        readonly IRandomNumberProvider _randomPressureSampleSimulator;

        public Sensor(IRandomNumberProvider rnd)
        {
            this._randomPressureSampleSimulator = rnd;
        }

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = ReadPressureSample();

            return Offset + pressureTelemetryValue;
        }

        public double ReadPressureSample()
        {
            var firstRndNum = this._randomPressureSampleSimulator.RandomNumberProv.NextDouble();
            var secondRndNum = this._randomPressureSampleSimulator.RandomNumberProv.NextDouble();
            // Simulate info read from a real sensor in a real tire
            return 6 * firstRndNum  * secondRndNum;
        }
    }
}
