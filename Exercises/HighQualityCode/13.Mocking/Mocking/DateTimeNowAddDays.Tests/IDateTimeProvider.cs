namespace DateTimeNowAddDays.Tests
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime DateTimeNow { get; }
    }
}
