namespace NovelNest.Core.Models.QueryModels.Book
{
    using NovelNest.Core.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AllBookReviewsQueryModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = null!;
        public int ReviewsPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public BookReviewSorting Sorting { get; set; }

        public int TotalBookReviewsCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<BookReviewServiceModel> BookReviews { get; set; } = new HashSet<BookReviewServiceModel>();
    }
}
