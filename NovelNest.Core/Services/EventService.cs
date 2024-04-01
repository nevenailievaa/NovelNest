namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Event;
    using NovelNest.Core.Models.ViewModels.Event;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Events;
    using System.Linq;
    using System.Threading.Tasks;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.EventConstants;

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

        public async Task<bool> EventExistsAsync(int eventId)
        {
            return await repository.AllAsReadOnly<Event>()
                .AnyAsync(e => e.Id == eventId);
        }

        public async Task<Event> FindEventByIdAsync(int eventId)
        {
            return await repository.GetByIdAsync<Event>(eventId);
        }

        public async Task<EventDetailsViewModel> DetailsAsync(int eventId)
        {
            Event? currentEvent = await repository.GetByIdAsync<Event>(eventId);

            var currentEventDetails = new EventDetailsViewModel()
            {
                Id = currentEvent.Id,
                Topic = currentEvent.Topic,
                Description = currentEvent.Description,
                Location = currentEvent.Location,
                StartDate = currentEvent.StartDate,
                EndDate = currentEvent.EndDate,
                Seats = currentEvent.Seats,
                TicketPrice= currentEvent.TicketPrice,
                ImageUrl = currentEvent.ImageUrl
            };

            return currentEventDetails;
        }

        public async Task<int> AddAsync(EventAddViewModel eventForm)
        {
            Event currentEvent = new Event()
            {
                Topic = eventForm.Topic,
                Description = eventForm.Description,
                Location = eventForm.Location,
                StartDate = eventForm.StartDate,
                EndDate = eventForm.EndDate,
                ImageUrl = eventForm.ImageUrl,
                Seats = eventForm.Seats,
                TicketPrice = eventForm.TicketPrice
            };

            await repository.AddAsync(currentEvent);
            await repository.SaveChangesAsync();

            return currentEvent.Id;
        }

        public async Task<EventEditViewModel> EditGetAsync(int eventId)
        {
            var currentEvent = await repository.GetByIdAsync<Event>(eventId);

            var eventForm = new EventEditViewModel()
            {
                Id = eventId,
                Topic =  currentEvent.Topic,
                Description= currentEvent.Description,
                Location= currentEvent.Location,
                Seats= currentEvent.Seats,
                TicketPrice = currentEvent.TicketPrice,
                StartDate = currentEvent.StartDate,
                EndDate = currentEvent.EndDate,
                ImageUrl = currentEvent.ImageUrl
            };

            return eventForm;
        }

        public async Task<int> EditPostAsync(EventEditViewModel eventForm)
        {
            var currentEvent = await repository.GetByIdAsync<Event>(eventForm.Id);

            currentEvent.Topic = eventForm.Topic;
            currentEvent.Description = eventForm.Description;
            currentEvent.Location = eventForm.Location;
            currentEvent.Seats = eventForm.Seats;
            currentEvent.TicketPrice = eventForm.TicketPrice;
            currentEvent.StartDate = eventForm.StartDate;
            currentEvent.EndDate = eventForm.EndDate;
            currentEvent.ImageUrl = eventForm.ImageUrl;

            await repository.SaveChangesAsync();

            return currentEvent.Id;
        }
    }
}