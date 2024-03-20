namespace NovelNest.Core.Models.QueryModels.Book
{
    public class BookReviewQueryServiceModel
    {
        public int TotalReviewsCount { get; set; }
        public IEnumerable<BookReviewServiceModel> BookReviews { get; set; } = new HashSet<BookReviewServiceModel>();
    }
}