using NovelNest.Core.Models.ViewModels.Book;

namespace NovelNest.Core.Contracts
{
    public interface IPublisherService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<int?> GetPublisherIdAsync(string UserId);

        Task<int> AddBookAsync(BookAddViewModel bookForm);
        Task<BookEditViewModel> EditBookGetAsync(int bookId);
        Task<int> EditBookPostAsync(BookEditViewModel bookForm);
        Task<BookDeleteViewModel> DeleteBookAsync(int bookId);
        Task<int> DeleteBookConfirmedAsync(int bookId);
    }
}