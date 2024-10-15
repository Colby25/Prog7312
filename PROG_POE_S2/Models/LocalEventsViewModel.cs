using System.Collections.Generic;

namespace PROG_POE_S2.Models
{
    public class LocalEventsViewModel
    {
        // List to hold events to be displayed
        public List<EventModel> Events { get; set; }

        // reference: https://www.geeksforgeeks.org/hashset-in-c-sharp-with-examples/
        // Set to hold recommended events (ensuring uniqueness)
        public HashSet<EventModel> RecommendedEvents { get; set; }

        // Constructor to initialize the Events and RecommendedEvents collections
        public LocalEventsViewModel()
        {
            Events = new List<EventModel>(); // Initializes the list of events
            RecommendedEvents = new HashSet<EventModel>(); // Initializes the set of recommended events
        }
    }
}
