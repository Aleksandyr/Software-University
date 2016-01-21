using TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private ISensor _sensor;
        private bool _alarmOn;

        public Alarm(ISensor sensor)
        {
            this._sensor = sensor;
            this.AlarmOn = false;
        }

        public void Check()
        {
            double psiPressureValue = this._sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this.AlarmOn = true;
            }
            else
            {
                this.AlarmOn = false;
            }
        }

        public bool AlarmOn
        {
            get
            {
                return _alarmOn; 
                
            }
            private set
            {
                this._alarmOn = value;
            }
        }

    }
}
