namespace NovelNest.Core.Models.QueryModels.Book
{
    using NovelNest.Core.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AllBooksQueryModel
    {
        public int BooksPerPage { get; } = 4;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public BookSorting Sorting { get; set; }

        public int TotalBooksCount { get; set; }
        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Жанр")]
        public string Genre { get; set; } = null!;
        public IEnumerable<string> Genres { get; set; } = null!;

        [Display(Name = "Корица")]
        public string CoverType { get; set; } = null!;
        public IEnumerable<string> CoverTypes { get; set; } = null!;

        public IEnumerable<BookServiceModel> Books { get; set; } = new HashSet<BookServiceModel>();
    }
}