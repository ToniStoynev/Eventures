namespace Eventures.Controllers
{
    using System.Linq;
    using Eventures.Services;
    using Eventures.Models.BindingModels;
    using Eventures.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Eventures.Services.Models;

    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this.eventService
                             .GetAll()
                             .Select(e => new EventsAllViewModel()
                             {
                                 Name = e.Name,
                                 Place = e.Place,
                                 Start = e.Start,
                                 End = e.End
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

            var serviceModel = new CreateEventServiceModel()
            {
                Name = input.Name,
                Place = input.Place,
                Start = input.Start,
                End = input.End,
                PricePerTicket = input.PricePerTicket,
                TotalTickets = input.TotalTickets
            };

            this.eventService.CreateEvent(serviceModel);

            return this.Redirect("All");
        }
    }
}