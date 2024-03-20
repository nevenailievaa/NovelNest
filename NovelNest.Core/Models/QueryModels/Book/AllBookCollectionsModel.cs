namespace NovelNest.Core.Models.QueryModels.Book
{
    public class AllBookCollectionsModel
    {
        public BookQueryServiceModel booksUserWantsToRead { get; set; } = null!;
        public BookQueryServiceModel booksUserCurrentlyReading { get; set; } = null!;
        public BookQueryServiceModel booksUserRead { get; set; } = null!;
    }
}