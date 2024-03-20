namespace NovelNest.Infrastructure.Data.Models.Books
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.BookReviewConstants;

    public class BookReview
    {
        [Key]
        [Comment("The current Book Review's Identifier")]
        public int Id { get; set; }

        [MaxLength(BookReviewTitleMaxLength)]
        [Comment("The current Book Review's Title")]
        public string Title { get; set; } = null!;

        [MaxLength(BookReviewDescriptionMaxLength)]
        [Comment("The current Book Review's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The current Book Review's Rate")]
        public int Rate { get; set; }


        [Required]
        [Comment("The current Book's Identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("The current Book")]
        public Book Book { get; set; } = null!;

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public IdentityUser User { get; set; } = null!;
    }
}