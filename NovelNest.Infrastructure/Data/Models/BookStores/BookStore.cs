namespace NovelNest.Infrastructure.Data.Models.BookStores
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data.Models.Mappings;
    using System.ComponentModel.DataAnnotations;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookStoreConstants;

    public class BookStore
    {
        [Key]
        [Comment("The current BookStore's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookStoreNameMaxLength)]
        [Comment("The current BookStore's Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(BookStoreLocationMaxLength)]
        [Comment("The current BookStore's Location")]
        public string Location { get; set; } = null!;

        [Required]
        [Comment("The current BookStore's Mobile Contact")]
        public string Contact { get; set; } = null!;

        [Required]
        [MaxLength(BookStoreImageUrlMaxLength)]
        [Comment("The current BookStore's Image Url")]
        public string ImageUrl { get; set; } = null!;

        public ICollection<BookBookStore> BooksBookStores { get; set; } = new HashSet<BookBookStore>();
    }
}