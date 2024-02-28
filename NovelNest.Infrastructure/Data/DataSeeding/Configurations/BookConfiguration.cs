namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.Books;

    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Book[] { data.AnnaKarenina, data.Hannibal, data.MenWhoHateWomen, data.MeBeforeYou, data.TheDiaryOfAYoungGirl });
        }
    }
}