namespace NovelNest.Core.Models.QueryModels.Book
{
    public class AllBookCollectionsModel
    {
        public BookQueryServiceModel booksUserWantsToRead { get; set; } = null!;
        public IEnumerable<BookServiceModel> booksUserCurrentlyReading { get; set; } = null!;
        public IEnumerable<BookServiceModel> booksUserRead { get; set; } = null!;
    }
}