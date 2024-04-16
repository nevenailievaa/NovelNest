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
                data.BookOne,
                data.BookTwo,
                data.BookThree,
                data.BookFour,
                data.BookFive,
                data.BookSix,
                data.BookSeven,
                data.BookEight,
                data.BookNine,
                data.BookTen,
                data.BookEleven,
                data.BookTwelve,
                data.BookThirteen,
                data.BookFourteen,
                data.BookFiveteen,
                data.BookSixteen,
                data.BookSeventeen
            });
        }
    }
}