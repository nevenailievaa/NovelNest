namespace NovelNest.Core.Models.ViewModels.Event
{
    using NovelNest.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.EventConstants;

    public class EventAddViewModel : IEventModel
    {
        [Required]
        [StringLength(EventTopicMaxLength, MinimumLength = EventTopicMinLength, ErrorMessage = LengthErrorMessage)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(EventLocationMaxLength, MinimumLength = EventLocationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Location { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;

        [Required]
        [Range(EventSeatsMinRange, EventSeatsMaxRange)]
        public int Seats { get; set; }

        [Required]
        [Range(EventTicketPriceMinRange, EventTicketPriceMaxRange)]
        public decimal TicketPrice { get; set; }

        [Required]
        [StringLength(EventImageUrlMaxLength, MinimumLength = EventImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}