namespace NovelNest.Core.Models.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookReviewConstants;

    public class BookReviewAddViewModel
    {

        [StringLength(BookReviewTitleMaxLength, MinimumLength = BookReviewTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string? Title { get; set; } = null!;

        [StringLength(BookReviewDescriptionMaxLength, MinimumLength = BookReviewDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string? Description { get; set; }

        [Required]
        [Range(BookReviewRateMinRange, BookReviewRateMaxRange, ErrorMessage = RangeErrorMessage)]
        public int Rate { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}
