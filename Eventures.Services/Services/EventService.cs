namespace Eventures.Services
{
    using Eventures.Data;
    using Eventures.Domain;
    using Eventures.Services.Mapping;
    using Eventures.Services.Models;
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
            var evt = AutoMapper.Mapper.Map<Event>(model);
        
            this.db.Events.Add(evt);

            int result = await this.db.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<EventsAllServiceModel> GetAll()
        {
            return  this.db
                    .Events
                    .To<EventsAllServiceModel>();
        }
    }
}
