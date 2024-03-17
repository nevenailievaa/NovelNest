namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookUserActions;
    using NovelNest.Infrastructure.Data.Models.Mappings;
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

        public async Task<BookQueryServiceModel> AllAsync(string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 8)
        {
            var booksToShow = repository.AllAsReadOnly<Book>();

            if (genre != null)
            {
                booksToShow = booksToShow
                    .Where(b => b.Genre.Name.ToLower() == genre.ToLower());
            }

            if (coverType != null)
            {
                booksToShow = booksToShow
                    .Where(b => b.CoverType.Name.ToLower() == coverType.ToLower());
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                booksToShow = booksToShow
                .Where(b => normalizedSearchTerm.Contains(b.Title.ToLower())
                || normalizedSearchTerm.Contains(b.Author.ToLower())
                || normalizedSearchTerm.Contains(b.PublishingHouse.ToLower())
                || normalizedSearchTerm.Contains(b.Genre.Name.ToLower())
                || normalizedSearchTerm.Contains(b.CoverType.Name.ToLower())

                || b.Title.ToLower().Contains(normalizedSearchTerm)
                || b.Author.ToLower().Contains(normalizedSearchTerm)
                || b.PublishingHouse.ToLower().Contains(normalizedSearchTerm)
                || b.Genre.Name.ToLower().Contains(normalizedSearchTerm)
                || b.CoverType.Name.ToLower().Contains(normalizedSearchTerm));
            }

            booksToShow = sorting switch
            {
                BookSorting.Oldest => booksToShow.OrderBy(b => b.Id),
                BookSorting.PriceAscending => booksToShow.OrderBy(b => b.Price).ThenByDescending(b => b.Id),
                BookSorting.PriceDescending => booksToShow.OrderByDescending(b => b.Price).ThenByDescending(b => b.Id),
                BookSorting.TitleAscending => booksToShow.OrderBy(b => b.Title).ThenByDescending(b => b.Id),
                BookSorting.TitleDescending => booksToShow.OrderByDescending(b => b.Title).ThenByDescending(b => b.Id),
                BookSorting.AuthorAscending => booksToShow.OrderBy(b => b.Author).ThenByDescending(b => b.Id),
                BookSorting.AuthorDescending => booksToShow.OrderByDescending(b => b.Author).ThenByDescending(b => b.Id),
                _ => booksToShow.OrderByDescending(b => b.Id),
            };

            var books = await booksToShow
                .Skip((currentPage - 1) * booksPerPage)
                .Take(booksPerPage)
                .Select(b => new BookServiceModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price
                })
                .ToListAsync();

            int totalBooks = await booksToShow.CountAsync();

            return new BookQueryServiceModel()
            {
                Books = books,
                TotalBooksCount = totalBooks
            };
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
        public async Task<IEnumerable<string>> AllCoverTypesNamesAsync()
        {
            return await repository.AllAsReadOnly<CoverType>()
                .Select(ct => ct.Name)
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
        public async Task<IEnumerable<string>> AllGenresNamesAsync()
        {
            return await repository.AllAsReadOnly<Genre>()
                .Select(g => g.Name)
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

        public async Task<BookDeleteViewModel> DeleteAsync(int bookId)
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

        public async Task<int> DeleteConfirmedAsync(int bookId)
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
                await repository.RemoveRangeAsync(bookBookStores);
            }
            if (bookCarts != null && bookCarts.Any())
            {
                await repository.RemoveRangeAsync(bookCarts);
            }
            if (bookWantToReads != null && bookWantToReads.Any())
            {
                await repository.RemoveRangeAsync(bookWantToReads);
            }
            if (bookCurrentlyReadings != null && bookCurrentlyReadings.Any())
            {
                await repository.RemoveRangeAsync(bookCurrentlyReadings);
            }
            if (bookReads != null && bookReads.Any())
            {
                await repository.RemoveRangeAsync(bookReads);
            }
            if (bookReviews != null && bookReviews.Any())
            {
                await repository.RemoveRangeAsync(bookReviews);
            }

            await repository.RemoveAsync(book);
            await repository.SaveChangesAsync();

            return book.Id;
        }
    }
}
