namespace NovelNest.Infrastructure.Data.Models.Mappings
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data.Models.Events;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventParticipant
    {
        [Required]
        [Comment("The current Event's Identifier")]
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The current Event")]
        public Event Event { get; set; } = null!;


        [Required]
        [Comment("The current Participant's Identifier")]
        public string ParticipantId { get; set; } = null!;

        [ForeignKey(nameof(ParticipantId))]
        [Comment("The current Participant")]
        public IdentityUser Participant { get; set; } = null!;
    }
}