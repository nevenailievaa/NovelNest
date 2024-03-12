namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.ViewModels.Book;

    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> AllAsync();
        Task<IEnumerable<GenreViewModel>> AllGenresAsync();
        Task<IEnumerable<CoverTypeViewModel>> AllCoverTypesAsync();
        Task<bool> BookExistsAsync(int bookId);
        Task<bool> GenreExistsAsync(int genreId);
        Task<bool> CoverTypeExistsAsync(int coverTypeId);
        Task<int> AddAsync(BookAddViewModel bookForm);
        Task<BookEditViewModel> EditGetAsync(int bookId);
        Task<int> EditPostAsync(BookEditViewModel bookForm);
        Task<IEnumerable<BookAllViewModel>> SearchAsync(string input);
        Task<BookViewModel> DetailsAsync(int bookId);
        Task<BookDeleteViewModel> DeleteAsync(int bookId);
        Task<int> DeleteConfirmedAsync(int bookId);
    }
}