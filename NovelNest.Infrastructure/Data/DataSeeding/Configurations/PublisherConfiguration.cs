namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.Roles;

    internal class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Publisher[] { data.Publisher, data.PublisherAdmin });
        }
    }
}