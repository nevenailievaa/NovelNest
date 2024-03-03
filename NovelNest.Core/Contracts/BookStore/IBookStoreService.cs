using NovelNest.Core.ViewModels.BookStore;

namespace NovelNest.Core.Contracts.BookStore
{
    public interface IBookStoreService
    {
        Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStores();
    }
}