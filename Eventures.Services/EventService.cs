namespace Eventures.Services
{
    using Eventures.Data;
    using Eventures.Domain;
    using Eventures.Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class EventService : IEventService
    {
        private readonly EventuresDbContext db;

        public EventService(EventuresDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateEvent(CreateEventServiceModel model)
        {
            var ev = new Event
            {
                Name = model.Name,
                Place = model.Place,
                Start = model.Start,
                End = model.End,
                PricePerTicket = model.PricePerTicket,
                TotalTickets = model.TotalTickets
            };

            this.db.Events.Add(ev);

            int result = await this.db.SaveChangesAsync();

            return result > 0;
        }

        public IEnumerable<EventsAllServiceModel> GetAll()
        {
            return this.db
                    .Events
                    .Select(ev => new EventsAllServiceModel()
                    { 
                        Name = ev.Name,
                        Place = ev.Place,
                        Start = ev.Start,
                        End = ev.End
                    })
                    .ToList();
        }
    }
}
