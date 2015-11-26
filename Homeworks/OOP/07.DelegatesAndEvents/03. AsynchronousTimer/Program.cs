using System;
namespace AsynchronousTimer
{
    public class Program
    {
        static void Main()
        {
            Action getTime = GetTime;

            var timer = new AsyncTimer(getTime, 10, 1000);
            timer.StartTimer();
        }

        public static void GetTime()
        {
            var timeNow = DateTime.Now;
            Console.WriteLine("{0}", timeNow.ToString("HH:mm:ss"));
        }
    }
}
