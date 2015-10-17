using System.Collections.Generic;

namespace Events.Web.Models
{
    public class UpcomingPassedEventsViewModel
    {
        public IEnumerable<EventViewModel> UpcommingEvents { get; set; }

        public IEnumerable<EventViewModel> PassedEvents { get; set; }
    }
}