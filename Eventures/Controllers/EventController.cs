namespace Eventures.Controllers
{
    using System.Linq;
    using Eventures.Data;
    using Eventures.Domain;
    using Eventures.Models.BindingModels;
    using Eventures.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class EventController : Controller
    {
        private readonly EventuresDbContext db;

        public EventController(EventuresDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this.db.Events.Select(x => new EventsAllViewModel
            {
                Name = x.Name,
                Start = x.Start,
                End = x.End,
                Place = x.Place
            })
            .ToList();

            return View(events);
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateEventBindingModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

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