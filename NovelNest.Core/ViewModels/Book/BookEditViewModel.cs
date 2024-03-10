namespace NovelNest.Core.ViewModels.Book
{
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookConstants;

    public class BookEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength, ErrorMessage = LengthErrorMessage)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(BookPageMinValue, BookPageMaxValue, ErrorMessage = RangeErrorMessage)]
        public int Pages { get; set; }

        [Required]
        [StringLength(BookPublishingHouseMaxLength, MinimumLength = BookPublishingHouseMinLength, ErrorMessage = LengthErrorMessage)]
        public string PublishingHouse { get; set; } = null!;

        [Required]
        [Range(BookYearPublishedMinRange, BookYearPublishedMaxRange, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Year Published")]
        public int YearPublished { get; set; }

        [Required]
        [Range(typeof(decimal), BookPriceMinValue, BookPriceMaxValue, ErrorMessage = RangeErrorMessage,
            ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(BookImageUrlMaxLength, MinimumLength = BookImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;


        [Required]
        [Display(Name = "Cover Type")]
        public int CoverTypeId { get; set; }
        public IEnumerable<CoverTypeViewModel> CoverTypes { get; set; } = new HashSet<CoverTypeViewModel>();


        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();
    }
}