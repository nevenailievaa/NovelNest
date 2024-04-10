using NovelNest.Core.Enums;
using NovelNest.Core.Models.QueryModels.Book;
using NovelNest.Core.Models.ViewModels.Article;
using NovelNest.Core.Models.ViewModels.Book;
using NovelNest.Core.Models.ViewModels.BookStore;
using NovelNest.Core.Models.ViewModels.Event;
using NovelNest.Infrastructure.Data.Models.Mappings;

namespace NovelNest.Core.Contracts
{
    public interface IPublisherService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<int?> GetPublisherIdAsync(string UserId);

        //Book
        Task<int> AddBookAsync(BookAddViewModel bookForm);
        Task<BookEditViewModel> EditBookGetAsync(int bookId);
        Task<int> EditBookPostAsync(BookEditViewModel bookForm);
        Task<BookDeleteViewModel> DeleteBookAsync(int bookId);
        Task<int> DeleteBookConfirmedAsync(int bookId);

        //BookStore
        Task<int> AddBookStoreAsync(BookStoreAddViewModel bookStoreForm);
        Task<BookStoreEditViewModel> EditBookStoreGetAsync(int bookStoreId);
        Task<int> EditBookStorePostAsync(BookStoreEditViewModel bookStoreForm);
        Task<BookStoreDeleteViewModel> DeleteBookStoreAsync(int bookStoreId);
        Task<int> DeleteBookStoreConfirmedAsync(int bookStoreId);
        Task<BookQueryServiceModel> AllBooksToChooseAsync(
            int bookStoreId,
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);
        Task<bool> BookExistsInBookStoreAsync(int bookId, int bookStoreId);
        Task<BookBookStore> AddBookToBookStoreAsync(int bookId, int bookStoreId);
        Task<BookBookStoreDeleteViewModel> RemoveBookFromBookStoreAsync(int bookId, int bookStoreId);
        Task RemoveBookFromBookStoreConfirmedAsync(int bookId, int bookStoreId);

        //Article
        Task<int> AddArticleAsync(ArticleAddViewModel articleForm);
        Task<ArticleEditViewModel> EditArticleGetAsync(int articleId);
        Task<int> EditArticlePostAsync(ArticleEditViewModel articleForm);
        Task<ArticleDeleteViewModel> DeleteArticleAsync(int articleId);
        Task<int> DeleteArticleConfirmedAsync(int articleId);

        //Event
        Task<int> AddEventAsync(EventAddViewModel eventForm);
        Task<EventEditViewModel> EditEventGetAsync(int eventId);
        Task<int> EditEventPostAsync(EventEditViewModel eventForm);
        Task<EventDeleteViewModel> DeleteEventAsync(int eventId);
        Task<int> DeleteEventConfirmedAsync(int eventId);
    }
}