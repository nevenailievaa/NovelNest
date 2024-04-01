using NovelNest.Core.Contracts;

namespace NovelNest.Core.Models.ViewModels.Event
{
    public class EventDeleteViewModel : IEventModel
    {
        public int Id { get; set; }
        public string Topic { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}