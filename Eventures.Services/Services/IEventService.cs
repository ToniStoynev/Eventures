namespace Eventures.Services
{
    using Eventures.Services.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public  interface IEventService
    {
        Task<bool> CreateEvent(CreateEventServiceModel model);
        IQueryable<EventsAllServiceModel> GetAll();
    }
}
