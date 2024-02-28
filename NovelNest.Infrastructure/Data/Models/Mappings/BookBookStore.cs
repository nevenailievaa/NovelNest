namespace NovelNest.Infrastructure.Data.Models.Mappings
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookStores;

    public class BookBookStore
    {
        [Required]
        [Comment("The current Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The current Book")]
        public Book Book { get; set; } = null!;


        [Required]
        [Comment("The current BookStore's Identifier")]
        public int BookStoreId { get; set; }

        [ForeignKey(nameof(BookStoreId))]
        [Comment("The current BookStore")]
        public BookStore BookStore { get; set; } = null!;
    }
}