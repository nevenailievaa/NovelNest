using NovelNest.Core.Contracts;

namespace NovelNest.Core.Models.ViewModels.Event
{
    public class EventDetailsViewModel : IEventModel
    {
        public int Id { get; set; }
        public string Topic { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Seats { get; set; }
        public decimal TicketPrice { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}