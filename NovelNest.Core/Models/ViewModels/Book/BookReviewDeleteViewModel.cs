namespace NovelNest.Core.Models.ViewModels.Book
{
    public class BookReviewDeleteViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = null!;
        public int ReviewId { get; set; }
    }
}