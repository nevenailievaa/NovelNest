namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.BookStore;
    using NovelNest.Core.Models.ViewModels.BookStore;

    public interface IBookStoreService
    {
        Task<BookStoreQueryServiceModel> AllAsync(
            string? searchTerm = null,
            BookStoreStatus status = BookStoreStatus.All,
            int currentPage = 1,
            int bookStoresPerPage = 4);
        Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync();
    }
}