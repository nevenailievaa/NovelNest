namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.ViewModels.Event;

    public interface IEventService
    {
        Task<IEnumerable<EventAllViewModel>> AllAsync();
    }
}