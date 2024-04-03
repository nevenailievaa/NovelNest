namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.QueryModels.BookStore;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Infrastructure.Data.Models.BookStores;
    using NovelNest.Infrastructure.Data.Models.Mappings;

    public interface IBookStoreService
    {
        Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync();
        Task<BookStoreQueryServiceModel> AllAsync(
            string? searchTerm = null,
            BookStoreStatus status = BookStoreStatus.All,
            int currentPage = 1,
            int bookStoresPerPage = 4);
        Task<bool> BookStoreExistsAsync(int bookStoreId);
        Task<BookStore> FindBookStoreByIdAsync(int bookStoreId);
        Task<BookStoreDetailsViewModel> DetailsAsync(int bookStoreId);
        Task<int> AddAsync(BookStoreAddViewModel bookStoreForm);
        Task<BookStoreEditViewModel> EditGetAsync(int bookStoreId);
        Task<int> EditPostAsync(BookStoreEditViewModel bookStoreForm);
        Task<BookStoreDeleteViewModel> DeleteAsync(int bookStoreId);
        Task<int> DeleteConfirmedAsync(int bookStoreId);
        Task<BookQueryServiceModel> AllBooksAsync(
            int bookStoreId,
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);

        Task<BookQueryServiceModel> AllBooksToChooseAsync(
            int bookStoreId,
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);

        Task<bool> BookExistsInBookStoreAsync(int bookId, int bookStoreId);
        Task<BookBookStore> AddBookAsync(int bookId, int bookStoreId);
        Task<BookBookStoreDeleteViewModel> RemoveBookAsync(int bookId, int bookStoreId);
        Task RemoveBookConfirmedAsync(int bookId, int bookStoreId);
    }
}