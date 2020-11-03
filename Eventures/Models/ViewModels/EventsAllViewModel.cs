namespace Eventures.Models.ViewModels
{
    using Eventures.Services.Mapping;
    using Eventures.Services.Models;
    using System;
    public class EventsAllViewModel : IMapFrom<EventsAllServiceModel>
    {
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Place { get; set; }
    }
}
