namespace NovelNest.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Infrastructure.Data.Models;

    public class NovelNestDbContext : IdentityDbContext
    {
        public NovelNestDbContext(DbContextOptions<NovelNestDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BookUserWantToRead> BooksUsersWantToRead { get; set; } = null!;
        public DbSet<BookUserCurrentlyReading> BooksUsersCurrentlyReading { get; set; } = null!;
        public DbSet<BookUserRead> BooksUsersRead { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<CoverType> CoverTypes { get; set; } = null!;
        public DbSet<BookStore> BookStores { get; set; } = null!;
        public DbSet<BookBookStore> BooksBookStores { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookBookStore>()
                .HasKey(bbs => new { bbs.BookId, bbs.BookStoreId });

            builder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.EventId, ep.ParticipantId });

            builder.Entity<BookUserWantToRead>()
                .HasKey(buwr => new { buwr.BookId, buwr.UserId });

            builder.Entity<BookUserCurrentlyReading>()
                .HasKey(bucr => new { bucr.BookId, bucr.UserId });

            builder.Entity<BookUserRead>()
                .HasKey(bur => new { bur.BookId, bur.UserId });

            builder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18,2);

            base.OnModelCreating(builder);
        }
    }
}