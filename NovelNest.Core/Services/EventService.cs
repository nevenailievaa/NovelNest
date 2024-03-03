namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.ViewModels.Event;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Events;

    public class EventService : IEventService
    {
        private readonly IRepository repository;

        public EventService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<EventAllViewModel>> AllAsync()
        {
            return await repository.AllAsReadOnly<Event>()
                .OrderByDescending(e => e.StartDate)
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Id,
                    Topic = e.Topic,
                    Location = e.Location,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    ImageUrl = e.ImageUrl
                })
                .ToListAsync();
        }
    }
}
