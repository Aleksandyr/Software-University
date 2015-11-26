namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    public class AsyncTimer
    {
        public AsyncTimer(Action t, int tick, int tickInterval)
        {
            this.T = t;
            this.Tick = tick;
            this.TickInterval = tickInterval;
        }

        public Action T { get; set; }

        public int Tick { get; set; }

        public int TickInterval { get; set; }


        public void StartTimer()
        {
            for (int i = 0; i < this.Tick; i++)
            {
                Thread.Sleep(this.TickInterval);
                T.Invoke();
            }
        }
    }
}
