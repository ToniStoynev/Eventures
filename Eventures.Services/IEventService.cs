namespace Eventures.Services
{
    using Eventures.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public  interface IEventService
    {
        Task<bool> CreateEvent(CreateEventServiceModel model);
        IEnumerable<EventsAllServiceModel> GetAll();
    }
}
