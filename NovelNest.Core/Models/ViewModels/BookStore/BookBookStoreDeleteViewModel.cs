namespace NovelNest.Core.Models.ViewModels.BookStore
{
    public class BookBookStoreDeleteViewModel
    {
        public int BookId { get; set; }
        public int BookStoreId { get; set; }
        public string BookTitle { get; set; } = null!;
        public string BookStoreName { get; set; } = null!;
        public string BookImageUrl { get; set; } = null!;
    }
}