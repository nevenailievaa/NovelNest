namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Event;
    using NovelNest.Core.Models.ViewModels.Event;
    using NovelNest.Infrastructure.Data.Models.Events;

    public interface IEventService
    {
        Task<EventQueryServiceModel> AllAsync(
            string? searchTerm = null,
            EventSorting sorting = EventSorting.Newest,
            EventStatus status = EventStatus.All,
            int currentPage = 1,
            int eventsPerPage = 4);

        Task<bool> EventExistsAsync(int eventId);
        Task<Event> FindEventByIdAsync(int eventId);
        Task<EventDetailsViewModel> DetailsAsync(int eventId);
        Task<int> AddAsync(EventAddViewModel eventForm, DateTime startDate, DateTime endDate);
    }
}