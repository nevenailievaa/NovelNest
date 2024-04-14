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

            builder.HasData(new Book[]
            { 
                data.AnnaKarenina,
                data.Hannibal,
                data.MenWhoHateWomen,
                data.MeBeforeYou,
                data.TheDiaryOfAYoungGirl,
                data.Searched,
                data.QuoVadis,
                data.Tobacco,
                data.WomanInMe,
                data.AtMothers,
                data.TheWitcherOne,
                data.ImStillCountingTheDays,
                data.TheLettersWar,
                data.TheHungerGamesOne,
                data.TheHungerGamesTwo,
                data.TheHungerGamesThree,
                data.TheHungerGamesBalad
            });
        }
    }
}