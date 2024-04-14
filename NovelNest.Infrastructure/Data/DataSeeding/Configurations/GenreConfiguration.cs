namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.Books;

    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Genre[]
            {
                data.Poetry,
                data.Mystery,
                data.Fantasy,
                data.Thriller,
                data.Romance,
                data.ClassicLiterature,
                data.Horror,
                data.Adventure,
                data.Biography,
                data.Autobiography,
                data.Crime,
                data.Humor,
                data.Fiction,
                data.Drama,
                data.Military,
                data.History,
                data.Philosophy,
                data.Business,
                data.Science,
                data.Health,
                data.Cooking,
                data.Travel
            });
        }
    }
}