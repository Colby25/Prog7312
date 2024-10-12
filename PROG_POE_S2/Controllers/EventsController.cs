using Microsoft.AspNetCore.Mvc;
using PROG_POE_S2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG_POE_S2.Controllers
{
    public class EventsController : Controller
    {
        // Queue to store upcoming events
        private readonly Queue<EventModel> _upcomingEvents;

        // Constructor to initialize the events
        public EventsController()
        {
            _upcomingEvents = new Queue<EventModel>(new[]
            {
                new EventModel { Title = "Community Clean-up", Description = "Join the community clean-up event.", Date = DateTime.Now.AddDays(3), Category = "Community" },
                new EventModel { Title = "Local Music Festival", Description = "Enjoy live music performances.", Date = DateTime.Now.AddDays(7), Category = "Music" },
                new EventModel { Title = "Sports Day", Description = "Participate in local sports activities.", Date = DateTime.Now.AddDays(5), Category = "Sports" },
            });
        }

        // Action method to display local events
        public IActionResult LocalEvents()
        {
            // Convert the Queue to a List for display purposes
            var eventsList = _upcomingEvents.ToList();

            //  view model using the Queue for events and HashSet for recommended events
            var viewModel = new LocalEventsViewModel
            {
                Events = eventsList,
                RecommendedEvents = new HashSet<EventModel>() 
            };

            return View(viewModel);
        }

        // Action to search events based on category and date
        [HttpGet]
        public IActionResult SearchEvents(string category, DateTime? date)
        {
            // Filter events based on category and date from the queue
            var filteredEvents = _upcomingEvents.AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "all")
            {
                filteredEvents = filteredEvents
                    .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (date.HasValue)
            {
                filteredEvents = filteredEvents
                    .Where(e => e.Date.Date == date.Value.Date);
            }

            // Return filtered list from the queue
            var viewModel = new LocalEventsViewModel
            {
                Events = filteredEvents.ToList(),
                RecommendedEvents = new HashSet<EventModel>() 
            };

            return View("LocalEvents", viewModel);
        }
    }
}
