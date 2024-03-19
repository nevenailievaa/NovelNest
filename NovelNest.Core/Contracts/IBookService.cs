namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Book;

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
        Task<bool> BookExistsAsync(int bookId);
        Task<bool> GenreExistsAsync(int genreId);
        Task<bool> CoverTypeExistsAsync(int coverTypeId);
        Task<int> AddAsync(BookAddViewModel bookForm);
        Task<BookEditViewModel> EditGetAsync(int bookId);
        Task<int> EditPostAsync(BookEditViewModel bookForm);
        Task<BookViewModel> DetailsAsync(int bookId);
        Task<BookDeleteViewModel> DeleteAsync(int bookId);
        Task<int> DeleteConfirmedAsync(int bookId);
        Task<IEnumerable<BookServiceModel>> AllWantToReadBooksIdsByUserIdAsync(string userId);
        Task<IEnumerable<BookServiceModel>> AllCurrentlyReadingBooksIdsByUserIdAsync(string userId);
        Task<IEnumerable<BookServiceModel>> AllReadBooksIdsByUserIdAsync(string userId);
        Task<bool> BookIsInAnotherCollectionAsync(int bookId, string userId);
        Task<int> RemoveBookFromAllCollectionsAsync(int bookId, string userId);
        Task<bool> BookIsNotCurrentlyReadingAsync(int bookId, string userId);
        Task<bool> BookIsNotWantToReadAsync(int bookId, string userId);
        Task<bool> BookIsNotReadAsync(int bookId, string userId);
        Task<int> AddWantToReadBookAsync(int bookId, string userId);
        Task<int> AddCurrentlyReadingBookAsync(int bookId, string userId);
        Task<int> AddReadBookAsync(int bookId, string userId);
        Task<int> RemoveWantToReadBookAsync(int bookId, string userId);
        Task<int> RemoveCurrentlyReadingBookAsync(int bookId, string userId);
        Task<int> RemoveReadBookAsync(int bookId, string userId);
    }
}