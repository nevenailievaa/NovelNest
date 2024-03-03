namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.ViewModels.BookStore;

    public interface IBookStoreService
    {
        Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync();
    }
}