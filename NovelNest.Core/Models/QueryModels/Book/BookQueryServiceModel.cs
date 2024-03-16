namespace NovelNest.Core.Models.QueryModels.Book
{
    public class BookQueryServiceModel
    {
        public int TotalBooksCount { get; set; }
        public IEnumerable<BookServiceModel> Books { get; set; } = new HashSet<BookServiceModel>();
    }
}