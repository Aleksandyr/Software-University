using TheaterSystem.Models;

namespace TheaterSystem
{
    using System;
    using System.Collections.Generic;
    using TheaterSystem.Models;

    public interface IPerformanceDatabase
    {
        /// <summary>
        /// This method add theater to the database, and can throw duplicate exception
        /// </summary>
        /// <param name="theatreName"></param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// This method list all theaters
        /// </summary>
        /// <returns>Collection of theaters</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// This method add performances to the database, 
        /// and can throw Theater not found and time duration overlap
        /// </summary>
        /// <param name="theatreName"></param>
        /// <param name="performanceTitle"></param>
        /// <param name="startDateTime"></param>
        /// <param name="duration"></param>
        /// <param name="price"></param>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// This method list all performances
        /// </summary>
        /// <returns>Collection of performances</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// This method list performances for current theater
        /// </summary>
        /// <param name="theatreName"></param>
        /// <returns>Collection of performances</returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}