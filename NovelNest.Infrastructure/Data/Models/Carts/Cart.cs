namespace NovelNest.Infrastructure.Data.Models.Carts
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data.Models.Mappings;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public IdentityUser User { get; set; } = null!;

        public ICollection<BookCart> BooksCarts { get; set; } = new HashSet<BookCart>();
        public ICollection<EventCart> EventsCarts { get; set; } = new HashSet<EventCart>();
    }
}