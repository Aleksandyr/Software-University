using TheaterSystem.Exceptions;
using TheaterSystem.Models;

namespace TheaterSystem.Data
{
    using System;
    using System.Collections.Generic;

    using TheaterSystem.Exceptions;
    using TheaterSystem.Models;

    public class TheatreDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> theaterWithSortedPerformances;

        public TheatreDatabase()
        {
            this.theaterWithSortedPerformances = new SortedDictionary<string, SortedSet<Performance>>();
        }


        public void AddTheatre(string theatreName)
        {
            // BUG FIXED: Theater should exist!
            if (this.theaterWithSortedPerformances.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.theaterWithSortedPerformances.Add(theatreName, new SortedSet<Performance>());
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.theaterWithSortedPerformances.Keys;

            return theatres;
        }

        public void AddPerformance(string theatreName,
            string performanceName, DateTime dateTime, TimeSpan duration, decimal price)
        {
            var isTheaterExist = this.theaterWithSortedPerformances.ContainsKey(theatreName);
            if (!isTheaterExist)
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.theaterWithSortedPerformances[theatreName];
            var endDateTime = dateTime + duration;
            var isOverlapping = IsPerformanceOverlapping(performances, dateTime, endDateTime);

            if (isOverlapping)
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(theatreName, performanceName, dateTime, duration, price);
            performances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.theaterWithSortedPerformances.Keys;
            var performances = new List<Performance>();

            foreach (var theatre in theatres)
            {
                var performance = this.theaterWithSortedPerformances[theatre];

                performances.AddRange(performance);
            }

            return performances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theaterWithSortedPerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performance = this.theaterWithSortedPerformances[theatreName];

            return performance;
        }

        private bool IsPerformanceOverlapping(IEnumerable<Performance>performances, DateTime dateTime, DateTime endDateTime)
        {
            foreach (var performance in performances)
            {
                var performanceStartDate = performance.StartDate;
                var performanceEndDate = performance.StartDate + performance.Duration;

                if ((performanceStartDate <= dateTime && dateTime <= performanceEndDate) || 
                    (performanceStartDate <= endDateTime && endDateTime <= performanceEndDate) || 
                    (dateTime <= performanceStartDate && performanceStartDate <= endDateTime) || 
                    (dateTime <= performanceEndDate && performanceEndDate <= endDateTime))
                {
                    return true;
                }
            }

            return false;
        }
    }
}