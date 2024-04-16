namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NovelNest.Infrastructure.Data.Models.BookStores;

    internal class BookStoreConfiguration : IEntityTypeConfiguration<BookStore>
    {
        public void Configure(EntityTypeBuilder<BookStore> builder)
        {
            var data = new DataSeed();

            builder.HasData(new BookStore[] { data.BookStoreOne, data.BookStoreTwo, data.BookStoreThree });
        }
    }
}