namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Article;
    using NovelNest.Core.Models.QueryModels.Event;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.Events;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly IRepository repository;

        public EventService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EventQueryServiceModel> AllAsync(
            string? searchTerm = null,
            EventSorting sorting = EventSorting.Newest,
            EventStatus status = EventStatus.All,
            int currentPage = 1,
            int eventsPerPage = 4)
        {
            var eventsToShow = repository.AllAsReadOnly<Event>();

            if (status == EventStatus.Upcoming)
            {
                eventsToShow = eventsToShow
                    .Where(e => e.StartDate > DateTime.Now);
            }
            else if (status == EventStatus.Previous)
            {
                eventsToShow = eventsToShow
                    .Where(e => e.StartDate <= DateTime.Now);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                eventsToShow = eventsToShow
                .Where(e => normalizedSearchTerm.Contains(e.Topic.ToLower())
                || normalizedSearchTerm.Contains(e.Location.ToLower())
                || normalizedSearchTerm.Contains(e.StartDate.ToString().ToLower())
                || normalizedSearchTerm.Contains(e.EndDate.ToString().ToLower())

                || e.Topic.ToLower().Contains(normalizedSearchTerm)
                || e.Location.ToLower().Contains(normalizedSearchTerm)
                || e.StartDate.ToString().ToLower().Contains(normalizedSearchTerm)
                || e.EndDate.ToString().ToLower().Contains(normalizedSearchTerm));
            }

            eventsToShow = sorting switch
            {
                EventSorting.Oldest => eventsToShow.OrderBy(e => e.Id),
                EventSorting.PriceAscending => eventsToShow.OrderBy(e => e.TicketPrice).ThenByDescending(a => a.Id),
                EventSorting.PriceDescending => eventsToShow.OrderByDescending(e => e.TicketPrice).ThenByDescending(a => a.Id),
                _ => eventsToShow.OrderByDescending(e => e.Id)
            };

            var events = await eventsToShow
                .Skip((currentPage - 1) * eventsPerPage)
                .Take(eventsPerPage)
                .Select(e => new EventServiceModel()
                {
                    Id = e.Id,
                    Topic = e.Topic,
                    Location = e.Location,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    ImageUrl = e.ImageUrl,
                    Seats = e.Seats,
                    TicketPrice = e.TicketPrice
                })
                .ToListAsync();

            int totalEvents = await eventsToShow.CountAsync();

            return new EventQueryServiceModel()
            {
                Events = events,
                TotalEventsCount = totalEvents
            };
        }
    }
}
