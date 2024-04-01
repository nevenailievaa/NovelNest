namespace NovelNest.Core.Models.QueryModels.Event
{
    public class EventQueryServiceModel
    {
        public int TotalEventsCount { get; set; }
        public IEnumerable<EventServiceModel> Events { get; set; } = new HashSet<EventServiceModel>();
    }
}