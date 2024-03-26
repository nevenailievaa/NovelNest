namespace NovelNest.Core.Models.QueryModels.Book
{
    using NovelNest.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookConstants;

    public class BookServiceModel : IBookModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength, ErrorMessage = LengthErrorMessage)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookImageUrlMaxLength, MinimumLength = BookImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), BookPriceMinValue, BookPriceMaxValue, ErrorMessage = RangeErrorMessage,
            ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
    }
}