namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Event;

    public interface IEventService
    {
        Task<EventQueryServiceModel> AllAsync(
            string? searchTerm = null,
            EventSorting sorting = EventSorting.Newest,
            EventStatus status = EventStatus.All,
            int currentPage = 1,
            int eventsPerPage = 4);
    }
}