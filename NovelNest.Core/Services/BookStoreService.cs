namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
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

        public async Task<IEnumerable<BookStoreAllViewModel>> AllAsync()
        {
            return await repository.AllAsReadOnly<BookStore>()
                .Select(bs => new BookStoreAllViewModel()
                {
                    Id = bs.Id,
                    Name = bs.Name,
                    Location = bs.Location,
                    OpeningTime = bs.OpeningTime,
                    ClosingTime = bs.ClosingTime,
                    ImageUrl = bs.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync()
        {
            return await repository
                .AllAsReadOnly<BookStore>()
                .OrderByDescending(b => b.BooksBookStores.Count)
                .Select(bs => new BookStoreIndexViewModel()
                {
                    Id = bs.Id,
                    Name = bs.Name,
                    ImageUrl = bs.ImageUrl
                })
                .Take(10)
                .ToListAsync();
        }
    }
}