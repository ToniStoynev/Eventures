using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Domain;
using Eventures.Models.BindingModels;
using Eventures.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class EventController : Controller
    {
        private readonly EventuresDbContext db;

        public EventController(EventuresDbContext db)
        {
            this.db = db;
        }
        public IActionResult All()
        {
            var events = this.db.Events.Select(x => new EventsAllViewModel
            {
                Name = x.Name,
                Start = x.Start.ToString("dd-MMM-yyyy HH:mm"),
                End = x.Start.ToString("dd-MMM-yyyy HH:mm"),
                Place = x.Place
            })
            .ToList();

            return View(events);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateEventBindingModel input)
        {
            var eventFordb = new Event
            {
                Name = input.Name,
                Place = input.Place,
                Start = input.Start,
                End  = input.End,
                TotalTickets = input.TotalTickets,
                PricePerTicket = input.PricePerTicket
            };
            this.db.Events.Add(eventFordb);
            this.db.SaveChanges();

            return this.Redirect("All");
        }
    }
}