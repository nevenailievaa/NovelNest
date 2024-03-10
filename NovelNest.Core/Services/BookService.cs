namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.ViewModels.Book;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Books;
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<bool> BookExistsAsync(int bookId)
        {
            return await repository.AllAsReadOnly<Book>()
                .AnyAsync(b => b.Id == bookId);
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

        public async Task<BookEditViewModel> EditGetAsync(int bookId)
        {
            var currentBook = await repository.All<Book>()
                .FirstOrDefaultAsync(b => b.Id == bookId);

            var bookForm = new BookEditViewModel()
            {
                Id = currentBook.Id,
                Title = currentBook.Title,
                Author  = currentBook.Author,
                Description= currentBook.Description,
                Pages= currentBook.Pages,
                PublishingHouse = currentBook.PublishingHouse,
                YearPublished = currentBook.YearPublished,
                Price = currentBook.Price,
                ImageUrl = currentBook.ImageUrl,
                CoverTypeId = currentBook.CoverTypeId,
                GenreId = currentBook.GenreId
            };

            bookForm.CoverTypes = await AllCoverTypesAsync();
            bookForm.Genres = await AllGenresAsync();

            return bookForm;
        }

        public async Task<int> EditPostAsync(BookEditViewModel bookForm)
        {
            var book = await repository.All<Book>()
                .Where(b => b.Id == bookForm.Id)
                .FirstOrDefaultAsync();

            book.Title = bookForm.Title;
            book.Author = bookForm.Author;
            book.Description = bookForm.Description;
            book.Pages = bookForm.Pages;
            book.PublishingHouse = bookForm.PublishingHouse;
            book.YearPublished = bookForm.YearPublished;
            book.Price = bookForm.Price;
            book.ImageUrl = bookForm.ImageUrl;
            book.CoverTypeId = bookForm.CoverTypeId;
            book.GenreId = bookForm.GenreId;

            await repository.SaveChangesAsync();

            return book.Id;
        }

        public async Task<IEnumerable<BookAllViewModel>> SearchAsync(string input)
        {
            var searchedBooks = await repository
                .AllAsReadOnly<Book>()
                .Where(b => input.ToLower().Contains(b.Title.ToLower())
                || input.ToLower().Contains(b.Author.ToLower())
                || input.ToLower().Contains(b.PublishingHouse.ToLower())
                || input.ToLower().Contains(b.Genre.Name.ToLower())
                || input.ToLower().Contains(b.CoverType.Name.ToLower())

                || b.Title.ToLower().Contains(input.ToLower())
                || b.Author.ToLower().Contains(input.ToLower())
                || b.PublishingHouse.ToLower().Contains(input.ToLower())
                || b.Genre.Name.ToLower().Contains(input.ToLower())
                || b.CoverType.Name.ToLower().Contains(input.ToLower()))
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

            return searchedBooks;
        }

        public async Task<BookViewModel> DetailsAsync(int bookId)
        {
            Book? currentBook = await repository.AllAsReadOnly<Book>()
                .FirstOrDefaultAsync(b => b.Id == bookId);

            Genre? currentGenre = await repository.AllAsReadOnly<Genre>()
                .FirstOrDefaultAsync(g => g.Id == currentBook.GenreId);

            CoverType? currentCoverType = await repository.AllAsReadOnly<CoverType>()
                .FirstOrDefaultAsync(ct => ct.Id == currentBook.CoverTypeId);

            var currentBookDetails = new BookViewModel()
            {
                Id = currentBook.Id,
                Title = currentBook.Title,
                Author = currentBook.Author,
                Genre = currentGenre.Name,
                Description = currentBook.Description,
                Pages = currentBook.Pages,
                PublishingHouse = currentBook.PublishingHouse,
                YearPublished = currentBook.YearPublished,
                CoverType = currentCoverType.Name,
                Price = currentBook.Price,
                ImageUrl = currentBook.ImageUrl
            };

            return currentBookDetails;
        }
    }
}
