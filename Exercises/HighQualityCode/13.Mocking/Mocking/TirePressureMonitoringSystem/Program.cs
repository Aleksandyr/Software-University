using System;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TirePressureMonitoringSystem.Interfaces;

namespace TirePressureMonitoringSystem
{
    public class Program
    {
        public static void Main()
        {
            Random rnd = new Random();
            RandomNumberProvider rndNumProv = new RandomNumberProvider(rnd);

            Sensor sensor = new Sensor(rndNumProv);

            Alarm alarm = new Alarm(sensor);
            for (int i = 0; i < 10; i++)
            {
                alarm.Check();
                Console.WriteLine(alarm.AlarmOn);
            }
        }
    }
}
