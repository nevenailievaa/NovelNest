namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookUserActions;
    using NovelNest.Infrastructure.Data.Models.Mappings;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using System.Threading.Tasks;

    public class PublisherService : IPublisherService
    {
        private readonly IRepository repository;
        private readonly IBookService bookService;
        private readonly IBookStoreService bookStoreService;
        private readonly IArticleService articleService;
        private readonly IEventService eventService;

        public PublisherService(IRepository repository, IBookService bookService)
        {
            this.repository = repository;
            this.bookService = bookService;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository
                .AllAsReadOnly<Publisher>()
                .AnyAsync(p => p.UserId == userId);
        }

        public async Task<int?> GetPublisherIdAsync(string userId)
        {
            return (await repository
                .AllAsReadOnly<Publisher>()
                .FirstOrDefaultAsync(p => p.UserId == userId))?.Id;
        }

        //Book
        public async Task<int> AddBookAsync(BookAddViewModel bookForm)
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

        public async Task<BookEditViewModel> EditBookGetAsync(int bookId)
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

            bookForm.CoverTypes = await bookService.AllCoverTypesAsync();
            bookForm.Genres = await bookService.AllGenresAsync();

            return bookForm;
        }

        public async Task<int> EditBookPostAsync(BookEditViewModel bookForm)
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

        public async Task<BookDeleteViewModel> DeleteBookAsync(int bookId)
        {
            var book = await repository
                .AllAsReadOnly<Book>().Where(b => b.Id == bookId)
                .FirstOrDefaultAsync();

            var deleteForm = new BookDeleteViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ImageUrl = book.ImageUrl,
            };

            return deleteForm;
        }

        public async Task<int> DeleteBookConfirmedAsync(int bookId)
        {
            var book = await repository
                .AllAsReadOnly<Book>().Where(b => b.Id == bookId)
                .FirstOrDefaultAsync();

            var bookBookStores = await repository.All<BookBookStore>()
                .Where(bbs => bbs.BookId == bookId)
                .ToListAsync();

            var bookCarts = await repository.All<BookCart>()
                .Where(bc => bc.BookId == bookId)
                .ToListAsync();

            var bookWantToReads = await repository.All<BookUserWantToRead>()
                .Where(buwtr => buwtr.BookId == bookId)
                .ToListAsync();

            var bookCurrentlyReadings = await repository.All<BookUserCurrentlyReading>()
                .Where(bucr => bucr.BookId == bookId)
                .ToListAsync();

            var bookReads = await repository.All<BookUserRead>()
                .Where(bur => bur.BookId == bookId)
                .ToListAsync();

            var bookReviews = await repository.All<BookReview>()
                .Where(br => br.BookId == bookId)
                .ToListAsync();

            if (bookBookStores != null && bookBookStores.Any())
            {
                await repository.RemoveRangeAsync<BookBookStore>(bookBookStores);
            }
            if (bookCarts != null && bookCarts.Any())
            {
                await repository.RemoveRangeAsync<BookCart>(bookCarts);
            }
            if (bookWantToReads != null && bookWantToReads.Any())
            {
                await repository.RemoveRangeAsync<BookUserWantToRead>(bookWantToReads);
            }
            if (bookCurrentlyReadings != null && bookCurrentlyReadings.Any())
            {
                await repository.RemoveRangeAsync<BookUserCurrentlyReading>(bookCurrentlyReadings);
            }
            if (bookReads != null && bookReads.Any())
            {
                await repository.RemoveRangeAsync<BookUserRead>(bookReads);
            }
            if (bookReviews != null && bookReviews.Any())
            {
                await repository.RemoveRangeAsync<BookReview>(bookReviews);
            }

            await repository.RemoveAsync<Book>(book);
            await repository.SaveChangesAsync();

            return book.Id;
        }
    }
}