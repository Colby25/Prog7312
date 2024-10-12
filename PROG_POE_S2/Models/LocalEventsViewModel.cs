using System.Collections.Generic;

namespace PROG_POE_S2.Models
{
    public class LocalEventsViewModel
    {
        public List<EventModel> Events { get; set; } = new List<EventModel>(); // Events from Queue
        public HashSet<EventModel> RecommendedEvents { get; set; } = new HashSet<EventModel>(); // For unique recommended events
    }
}
