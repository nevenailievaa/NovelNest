namespace NovelNest.Core.Services.BookStore
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts.BookStore;
    using NovelNest.Core.ViewModels.BookStore;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.BookStores;

    public class BookStoreService : IBookStoreService
    {
        private readonly IRepository repository;

        public BookStoreService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStores()
        {
            return await repository
                .AllAsReadOnly<BookStore>()
                .OrderByDescending(b => b.BooksBookStores.Count)
                .Select(b => new BookStoreIndexViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    ImageUrl = b.ImageUrl
                })
                .Take(10)
                .ToListAsync();
        }
    }
}