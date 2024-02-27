namespace NovelNest.Infrastructure.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookConstants;

    public class Book
    {
        [Key]
        [Comment("The current Book's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        [Comment("The current Book's Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(BookAuthorMaxLength)]
        [Comment("The current Book's Author")]
        public string Author { get; set; } = null!;

        [Required]
        [Comment("The current Book's Genre's Identifier")]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        [Comment("The current Book's Genre")]
        public Genre Genre { get; set; } = null!;

        [Required]
        [MaxLength(BookDescriptionMaxLength)]
        [Comment("The current Book's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The current Book's Pages Count")]
        public int Pages { get; set; }

        [Required]
        [MaxLength(BookPublishingHouseMaxLength)]
        [Comment("The current Book's Publishing House")]
        public string PublishingHouse { get; set; } = null!;

        [Required]
        [Comment("The date on which the curent Book was published")]
        public int YearPublished { get; set; }

        [Required]
        [Comment("The current Book's CoverType's Identifier")]
        public int CoverTypeId { get; set; }

        [ForeignKey(nameof(CoverTypeId))]
        [Comment("The current Book's CoverType")]
        public CoverType CoverType { get; set; } = null!;

        [Required]
        [Comment("The current Book's Price")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(BookImageUrlMaxLength)]
        [Comment("The current Book's cover image url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<BookBookStore> BooksBookStores { get; set; } = new HashSet<BookBookStore>();
    }
}