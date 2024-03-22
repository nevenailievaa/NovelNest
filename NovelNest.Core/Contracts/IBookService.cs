namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Infrastructure.Data.Models.Books;

    public interface IBookService
    {
        Task<BookQueryServiceModel> AllAsync(
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);
        Task<IEnumerable<GenreViewModel>> AllGenresAsync();
        Task<IEnumerable<string>> AllGenresNamesAsync();
        Task<IEnumerable<CoverTypeViewModel>> AllCoverTypesAsync();
        Task<IEnumerable<string>> AllCoverTypesNamesAsync();
        Task<Book> FindBookByIdAsync(int bookId);
        Task<bool> BookExistsAsync(int bookId);
        Task<bool> GenreExistsAsync(int genreId);
        Task<bool> CoverTypeExistsAsync(int coverTypeId);
        Task<int> AddAsync(BookAddViewModel bookForm);
        Task<BookEditViewModel> EditGetAsync(int bookId);
        Task<int> EditPostAsync(BookEditViewModel bookForm);
        Task<BookViewModel> DetailsAsync(int bookId);
        Task<BookDeleteViewModel> DeleteAsync(int bookId);
        Task<int> DeleteConfirmedAsync(int bookId);
        Task<BookQueryServiceModel> AllWantToReadBooksIdsByUserIdAsync(
            string userId,
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);
        Task<BookQueryServiceModel> AllCurrentlyReadingBooksIdsByUserIdAsync(
            string userId,
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);
        Task<BookQueryServiceModel> AllReadBooksIdsByUserIdAsync(string userId,
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);
        Task<bool> BookIsInAnotherCollectionAsync(int bookId, string userId);
        Task<int> RemoveBookFromAllCollectionsAsync(int bookId, string userId);
        Task<bool> BookIsCurrentlyReadingAsync(int bookId, string userId);
        Task<bool> BookIsWantToReadAsync(int bookId, string userId);
        Task<bool> BookIsReadAsync(int bookId, string userId);
        Task<int> AddWantToReadBookAsync(int bookId, string userId);
        Task<int> AddCurrentlyReadingBookAsync(int bookId, string userId);
        Task<int> AddReadBookAsync(int bookId, string userId);
        Task<int> RemoveWantToReadBookAsync(int bookId, string userId);
        Task<int> RemoveCurrentlyReadingBookAsync(int bookId, string userId);
        Task<int> RemoveReadBookAsync(int bookId, string userId);
        Task<int> AddBookReviewAsync(BookReviewAddViewModel reviewForm, string userId, int bookId);
        Task<BookReviewQueryServiceModel> AllBookReviewsAsync(
            int bookId,
            string bookTitle,
            string? searchTerm = null,
            BookReviewSorting sorting = BookReviewSorting.Newest,
            int currentPage = 1,
            int reviewsPerPage = 4);
        Task<BookReview> FindBookReviewAsync(int reviewId);
        Task<BookReviewDeleteViewModel> DeleteBookReviewAsync(int reviewId);
        Task<int> DeleteBookReviewConfirmedAsync(int reviewId);
        Task<BookReviewDetailsViewModel> BookReviewDetailsAsync(int reviewId);

    }
}