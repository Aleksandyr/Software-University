namespace TirePressureMonitoringSystem
{
    using System;
    using TirePressureMonitoringSystem.Interfaces;


    public class RandomNumberProvider : IRandomNumberProvider
    {
        public RandomNumberProvider(Random rnd)
        {
            this.RandomNumberProv = rnd;
        }

        public Random RandomNumberProv { get; }
    }
}
