﻿using System;
using System.Linq.Expressions;
using Events.Data;

namespace Events.Web.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Author { get; set; }

        public string Location { get; set; }

        public static Expression<Func<Event, EventViewModel>> ViewModel
        {
            get
            {
                return e => new EventViewModel()
                {
                    Id = e.Id,
                    Title = e.Title,
                    StartDateTime = e.StartDateTime,
                    Duration = e.Duration,
                    Author = e.Author.UserName,
                    Location = e.Location
                };
            }
        }
    }
}