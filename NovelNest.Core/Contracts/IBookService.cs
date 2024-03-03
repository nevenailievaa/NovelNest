namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.ViewModels.Book;

    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> All();
    }
}