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
                data.EventOne,
                data.EventTwo,
                data.EventThree,
                data.EventFour,
                data.EventFive,
                data.EventSix,
                data.EventSeven,
                data.EventEight,
                data.EventNine
            });
        }
    }
}