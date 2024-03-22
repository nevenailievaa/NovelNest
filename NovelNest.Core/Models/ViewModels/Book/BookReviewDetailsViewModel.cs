namespace NovelNest.Core.Models.ViewModels.Book
{
    public class BookReviewDetailsViewModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string AuthorId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Rate { get; set; }
    }
}