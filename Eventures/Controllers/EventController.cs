namespace Eventures.Controllers
{
    using Eventures.Services.Mapping;
    using Eventures.Services;
    using Eventures.Models.BindingModels;
    using Eventures.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Eventures.Services.Models;
    using System.Linq;

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
                             .To<EventsAllViewModel>()
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

            var serviceModel = AutoMapper.Mapper.Map<CreateEventServiceModel>(input);

            this.eventService.CreateEvent(serviceModel);

            return this.Redirect("All");
        }
    }
}