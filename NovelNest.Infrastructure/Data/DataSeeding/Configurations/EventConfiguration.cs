namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.Events;

    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Event[]
            {
                data.EventSofiasEtudes,
                data.EventAlbertBenbasat,
                data.EventTotalitarism,
                data.WhiteFoxDeath,
                data.PastUnfinished,
                data.AutographMeet,
                data.SelyaAhavaMeet,
                data.ForBooksAndReading,
                data.Fairytales
            });
        }
    }
}