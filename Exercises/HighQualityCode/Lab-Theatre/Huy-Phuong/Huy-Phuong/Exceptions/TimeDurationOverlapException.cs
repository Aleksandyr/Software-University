using System;

namespace TheaterSystem.Exceptions
{
    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string msg)
            : base(msg)
        { }
    }
}