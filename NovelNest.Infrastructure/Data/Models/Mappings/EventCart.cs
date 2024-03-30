namespace NovelNest.Infrastructure.Data.Models.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data.Models.Carts;
    using NovelNest.Infrastructure.Data.Models.Events;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventCart
    {
        [Required]
        [Comment("The current Event's Identifier")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The current Event")]
        public Event Event { get; set; } = null!;

        [Required]
        [Comment("The current Cart's Identifier")]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        [Comment("The current Cart")]
        public Cart Cart { get; set; } = null!;
    }
}
