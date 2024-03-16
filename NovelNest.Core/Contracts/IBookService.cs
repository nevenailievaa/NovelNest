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

        //Task<IEnumerable<BookAllViewModel>> AllAsync();
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

        //Task<IEnumerable<BookAllViewModel>> SearchAsync(string input);
        Task<BookViewModel> DetailsAsync(int bookId);
        Task<BookDeleteViewModel> DeleteAsync(int bookId);
        Task<int> DeleteConfirmedAsync(int bookId);
    }
}