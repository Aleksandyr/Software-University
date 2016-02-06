using System;

namespace TheaterSystem.Exceptions
{
    public class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string msg)
            : base(msg)
        {


        }
    }
}