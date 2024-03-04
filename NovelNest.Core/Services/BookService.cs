namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.ViewModels.Book;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Books;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly IRepository repository;

        public BookService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BookAllViewModel>> AllAsync()
        {
            return await repository
                .AllAsReadOnly<Book>()
                .Select(b => new BookAllViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    Pages = b.Pages,
                    PublishingHouse = b.PublishingHouse,
                    YearPublished = b.YearPublished
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CoverTypeViewModel>> AllCoverTypesAsync()
        {
            return await repository.AllAsReadOnly<CoverType>()
                .Select(ct => new CoverTypeViewModel()
                {
                    Id = ct.Id,
                    Name = ct.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GenreViewModel>> AllGenresAsync()
        {
            return await repository.AllAsReadOnly<Genre>()
                .Select(ct => new GenreViewModel()
                {
                    Id = ct.Id,
                    Name = ct.Name
                })
                .ToListAsync();
        }

        public async Task<bool> GenreExistsAsync(int genreId)
        {
            return await repository.AllAsReadOnly<Genre>()
                .AnyAsync(g => g.Id == genreId);
        }

        public async Task<bool> CoverTypeExistsAsync(int coverTypeId)
        {
            return await repository.AllAsReadOnly<CoverType>()
                .AnyAsync(ct => ct.Id == coverTypeId);
        }

        public async Task<int> AddAsync(BookAddViewModel bookForm)
        {
            Book book = new Book()
            {
                Title = bookForm.Title,
                Author = bookForm.Author,
                Description = bookForm.Description,
                Pages = bookForm.Pages,
                PublishingHouse = bookForm.PublishingHouse,
                YearPublished = bookForm.YearPublished,
                Price = bookForm.Price,
                ImageUrl = bookForm.ImageUrl,
                CoverTypeId = bookForm.CoverTypeId,
                GenreId = bookForm.GenreId
            };

            await repository.AddAsync(book);
            await repository.SaveChangesAsync();

            return book.Id;
        }
    }
}
