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
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<BookStore> BookStore { get; set; } = null!;
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

            builder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18,2);

            base.OnModelCreating(builder);
        }
    }
}