namespace Eventures.Services.Models
{
    using Eventures.Domain;
    using Eventures.Services.Mapping;
    using System;
    public class EventsAllServiceModel : IMapFrom<Event>
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
