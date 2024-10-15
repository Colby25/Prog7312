using Microsoft.AspNetCore.Mvc;
using PROG_POE_S2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG_POE_S2.Controllers
{
    public class EventsController : Controller
    {
        //reference: https://www.geeksforgeeks.org/sorteddictionary-implementation-in-c-sharp/ 
        // Sorted dictionary to hold upcoming events, keyed by date
        private readonly SortedDictionary<DateTime, Queue<EventModel>> _upcomingEvents;

        public EventsController()
        {
            // Initialize the upcoming events dictionary
            _upcomingEvents = new SortedDictionary<DateTime, Queue<EventModel>>();

            // Adds initial events to the upcoming events dictionary
            AddEvent(new EventModel { Title = "Community Clean-up", Description = "Join the community clean-up event.", Date = DateTime.Now.AddDays(3), Category = "Community" });
            AddEvent(new EventModel { Title = "Farmers Market", Description = "Support local farmers and vendors.", Date = DateTime.Now.AddDays(5), Category = "Community" });
            AddEvent(new EventModel { Title = "Park Renovation", Description = "Help renovate the community park.", Date = DateTime.Now.AddDays(10), Category = "Community" });
            AddEvent(new EventModel { Title = "Charity Walkathon", Description = "Walk for a cause and raise funds.", Date = DateTime.Now.AddDays(12), Category = "Community" });
            AddEvent(new EventModel { Title = "Local Food Drive", Description = "Donate food items for those in need.", Date = DateTime.Now.AddDays(7), Category = "Community" });
            AddEvent(new EventModel { Title = "Community Talent Show", Description = "Showcase your talent in front of the community.", Date = DateTime.Now.AddDays(7), Category = "Community" });

            AddEvent(new EventModel { Title = "Local Music Festival", Description = "Enjoy live music performances.", Date = DateTime.Now.AddDays(7), Category = "Festival" });
            AddEvent(new EventModel { Title = "Heritage Celebration", Description = "A festival celebrating local arts and history.", Date = DateTime.Now.AddDays(5), Category = "Festival" });
            AddEvent(new EventModel { Title = "Food Drive Festival", Description = "Celebrate cultural diversity with a variety of foods.", Date = DateTime.Now.AddDays(5), Category = "Festival" });
            AddEvent(new EventModel { Title = "Arts and Crafts Fair", Description = "Explore local artisans' work.", Date = DateTime.Now.AddDays(10), Category = "Festival" });
            AddEvent(new EventModel { Title = "Outdoor Movie Night", Description = "Watch classic films under the stars.", Date = DateTime.Now.AddDays(12), Category = "Festival" });
            AddEvent(new EventModel { Title = "Cultural Dance Festival", Description = "Experience local dance traditions.", Date = DateTime.Now.AddDays(14), Category = "Festival" });

            AddEvent(new EventModel { Title = "Sports Day", Description = "Participate in local sports activities.", Date = DateTime.Now.AddDays(5), Category = "Sports" });
            AddEvent(new EventModel { Title = "City Marathon", Description = "Run the city marathon and enjoy the scenic route.", Date = DateTime.Now.AddDays(7), Category = "Sports" });
            AddEvent(new EventModel { Title = "Local Football Tournament", Description = "Compete in the neighborhood football tournament.", Date = DateTime.Now.AddDays(3), Category = "Sports" });
            AddEvent(new EventModel { Title = "Swimming Gala", Description = "Join the community for a competitive swimming event.", Date = DateTime.Now.AddDays(12), Category = "Sports" });
            AddEvent(new EventModel { Title = "Basketball Championship", Description = "Watch the local teams compete for the championship.", Date = DateTime.Now.AddDays(10), Category = "Sports" });
            AddEvent(new EventModel { Title = "Tennis Open", Description = "Show off your tennis skills in the local open.", Date = DateTime.Now.AddDays(14), Category = "Sports" });

            AddEvent(new EventModel { Title = "Training Event", Description = "Develop your skills and discover your passions.", Date = DateTime.Now.AddDays(5), Category = "Education" });
            AddEvent(new EventModel { Title = "Coding Workshop", Description = "Learn the basics of coding.", Date = DateTime.Now.AddDays(7), Category = "Education" });
            AddEvent(new EventModel { Title = "Financial Literacy Seminar", Description = "Understand the fundamentals of finance.", Date = DateTime.Now.AddDays(10), Category = "Education" });
            AddEvent(new EventModel { Title = "Career Fair", Description = "Explore different career opportunities.", Date = DateTime.Now.AddDays(12), Category = "Education" });
            AddEvent(new EventModel { Title = "Public Speaking Workshop", Description = "Improve your public speaking skills.", Date = DateTime.Now.AddDays(3), Category = "Education" });
            AddEvent(new EventModel { Title = "Art & Design Seminar", Description = "Learn about the fundamentals of art and design.", Date = DateTime.Now.AddDays(14), Category = "Education" });
        }
        //refrence: https://stackoverflow.com/questions/61858644/c-sharp-add-event-to-value-inside-dictionarytkey-tvalue , 2020
        // Method to add an event to the upcoming events dictionary
        private void AddEvent(EventModel eventModel)
        {
            // Check if the date already exists in the dictionary
            if (!_upcomingEvents.ContainsKey(eventModel.Date.Date))
            {
                // If not, create a new queue for that date
                _upcomingEvents[eventModel.Date.Date] = new Queue<EventModel>();
            }
            // Enqueue the event to the queue for the specified date
            _upcomingEvents[eventModel.Date.Date].Enqueue(eventModel);
        }

        // Action method to retrieve and display local events
        public IActionResult LocalEvents()
        {
            // Combine all events from the dictionary into a single list
            var eventsList = _upcomingEvents.SelectMany(kvp => kvp.Value).ToList();
            // Create a view model with events and an empty recommended events set
            var viewModel = new LocalEventsViewModel
            {
                Events = eventsList,
                RecommendedEvents = new HashSet<EventModel>()
            };

            // Return the view with the populated view model
            return View(viewModel);
        }

        // method to search for events based on category and date
        [HttpGet]
        public IActionResult SearchEvents(string category, DateTime? date)
        {
            // Get all upcoming events as a queryable collection
            var filteredEvents = _upcomingEvents.SelectMany(kvp => kvp.Value).AsQueryable();

            // Filter events by category 
            if (!string.IsNullOrEmpty(category) && category != "all")
            {
                filteredEvents = filteredEvents
                    .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            // If a date is specified, filter events by date
            if (date.HasValue)
            {
                filteredEvents = filteredEvents
                    .Where(e => e.Date.Date == date.Value.Date);

                // Get recommended events (same category, different dates)
                var recommendedEvents = _upcomingEvents.SelectMany(kvp => kvp.Value)
                    .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && e.Date.Date != date.Value.Date)
                    .ToList();

                // Populate the view model with filtered and recommended events
                var viewModel = new LocalEventsViewModel
                {
                    Events = filteredEvents.ToList(),
                    RecommendedEvents = new HashSet<EventModel>(recommendedEvents)
                };

                // Return the view with the populated view model
                return View("LocalEvents", viewModel);
            }

            // If no date is specified, just return the filtered events
            var viewModelNoDate = new LocalEventsViewModel
            {
                Events = filteredEvents.ToList(),
                RecommendedEvents = new HashSet<EventModel>()
            };

            // Returns the view with the populated view model
            return View("LocalEvents", viewModelNoDate);
        }

       
    }
}
