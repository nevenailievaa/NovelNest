namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Core.Models.ViewModels.Event;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Articles;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookStores;
    using NovelNest.Infrastructure.Data.Models.BookUserActions;
    using NovelNest.Infrastructure.Data.Models.Events;
    using NovelNest.Infrastructure.Data.Models.Mappings;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using System.Threading.Tasks;

    public class PublisherService : IPublisherService
    {
        private readonly IRepository repository;
        private readonly IBookService bookService;

        public PublisherService(IRepository repository, IBookService bookService)
        {
            this.repository = repository;
            this.bookService = bookService;
        }

        public async Task<bool> ExistsByPublisherIdAsync(int publisherId)
        {
            return await repository
                .AllAsReadOnly<Publisher>()
                .AnyAsync(p => p.Id == publisherId);
        }

        public async Task<bool> ExistsByUserIdAsync(string userId)
        {
            return await repository
                .AllAsReadOnly<Publisher>()
                .AnyAsync(p => p.UserId == userId);
        }

        public async Task<bool> ExistsByEmailAsync(string publisherEmail)
        {
            return await repository.AllAsReadOnly<Publisher>().AnyAsync(u => u.User.Email.ToLower() == publisherEmail.ToLower());
        }

        public async Task<Publisher> GetPublisherByEmailAsync(string publisherEmail)
        {
            return await repository.All<Publisher>().FirstOrDefaultAsync(u => u.User.Email.ToLower() == publisherEmail.ToLower());
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


        //BookStore
        public async Task<int> AddBookStoreAsync(BookStoreAddViewModel bookStoreForm)
        {
            BookStore bookStore = new BookStore()
            {
                Name = bookStoreForm.Name,
                Location = bookStoreForm.Location,
                OpeningTime = new DateTime(bookStoreForm.OpeningTime.Year, bookStoreForm.OpeningTime.Month, bookStoreForm.OpeningTime.Day, bookStoreForm.OpeningTime.Hour, bookStoreForm.OpeningTime.Minute, 0),
                ClosingTime = new DateTime(bookStoreForm.ClosingTime.Year, bookStoreForm.ClosingTime.Month, bookStoreForm.ClosingTime.Day, bookStoreForm.ClosingTime.Hour, bookStoreForm.ClosingTime.Minute, 0),
                Contact = bookStoreForm.Contact,
                ImageUrl = bookStoreForm.ImageUrl
            };

            await repository.AddAsync(bookStore);
            await repository.SaveChangesAsync();

            return bookStore.Id;
        }

        public async Task<BookStoreEditViewModel> EditBookStoreGetAsync(int bookStoreId)
        {
            var currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreId);

            var articleForm = new BookStoreEditViewModel()
            {
                Id = bookStoreId,
                Name = currentBookStore.Name,
                Location = currentBookStore.Location,
                OpeningTime = currentBookStore.OpeningTime,
                ClosingTime = currentBookStore.ClosingTime,
                Contact = currentBookStore.Contact,
                ImageUrl = currentBookStore.ImageUrl
            };

            return articleForm;
        }

        public async Task<int> EditBookStorePostAsync(BookStoreEditViewModel bookStoreForm)
        {
            var currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreForm.Id);

            currentBookStore.Name = bookStoreForm.Name;
            currentBookStore.Location = bookStoreForm.Location;

            currentBookStore.OpeningTime = new DateTime(bookStoreForm.OpeningTime.Year, bookStoreForm.OpeningTime.Month, bookStoreForm.OpeningTime.Day, bookStoreForm.OpeningTime.Hour, bookStoreForm.OpeningTime.Minute, 0);

            currentBookStore.ClosingTime = new DateTime(bookStoreForm.ClosingTime.Year, bookStoreForm.ClosingTime.Month, bookStoreForm.ClosingTime.Day, bookStoreForm.ClosingTime.Hour, bookStoreForm.ClosingTime.Minute, 0);

            currentBookStore.Contact = bookStoreForm.Contact;
            currentBookStore.ImageUrl = bookStoreForm.ImageUrl;

            await repository.SaveChangesAsync();

            return currentBookStore.Id;
        }

        public async Task<BookStoreDeleteViewModel> DeleteBookStoreAsync(int bookStoreId)
        {
            var currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreId);

            var deleteForm = new BookStoreDeleteViewModel()
            {
                Id = bookStoreId,
                Name = currentBookStore.Name,
                ImageUrl = currentBookStore.ImageUrl
            };

            return deleteForm;
        }

        public async Task<int> DeleteBookStoreConfirmedAsync(int bookStoreId)
        {
            var currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreId);

            var booksInTheCurrentBookStore = await repository.All<BookBookStore>()
                .Where(bbs => bbs.BookStoreId == bookStoreId)
                .ToListAsync();

            if (booksInTheCurrentBookStore != null && booksInTheCurrentBookStore.Any())
            {
                await repository.RemoveRangeAsync<BookBookStore>(booksInTheCurrentBookStore);
            }

            await repository.RemoveAsync<BookStore>(currentBookStore);
            await repository.SaveChangesAsync();

            return currentBookStore.Id;
        }

        public async Task<BookQueryServiceModel> AllBooksToChooseAsync(
            int bookStoreId,
            string? genre = null,
            string? coverType = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4)
        {
            var booksToShow = repository.AllAsReadOnly<Book>()
                .Where(b => !b.BooksBookStores.Any(bbs => bbs.BookStoreId == bookStoreId));

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
                .ProjectToBookServiceModel()
                .ToListAsync();

            int totalBooks = await booksToShow.CountAsync();

            return new BookQueryServiceModel()
            {
                Books = books,
                TotalBooksCount = totalBooks
            };
        }

        public async Task<bool> BookExistsInBookStoreAsync(int bookId, int bookStoreId)
        {
            return await repository.AllAsReadOnly<BookBookStore>()
                .AnyAsync(bbs => bbs.BookId == bookId && bbs.BookStoreId == bookStoreId);
        }

        public async Task<BookBookStore> AddBookToBookStoreAsync(int bookId, int bookStoreId)
        {
            var bookBookStore = await repository.All<BookBookStore>()
                .Where(bbs => bbs.BookId == bookId && bbs.BookStoreId == bookStoreId)
                .FirstOrDefaultAsync();

            if (bookBookStore == null)
            {
                bookBookStore = new BookBookStore()
                {
                    BookId = bookId,
                    BookStoreId = bookStoreId
                };

                await repository.AddAsync(bookBookStore);
                await repository.SaveChangesAsync();
            }

            return bookBookStore;
        }

        public async Task<BookBookStoreDeleteViewModel> RemoveBookFromBookStoreAsync(int bookId, int bookStoreId)
        {
            var book = await repository.GetByIdAsync<Book>(bookId);
            var bookStore = await repository.GetByIdAsync<BookStore>(bookStoreId);

            var deleteForm = new BookBookStoreDeleteViewModel()
            {
                BookId = bookId,
                BookStoreId = bookStoreId,
                BookTitle = book.Title,
                BookImageUrl = book.ImageUrl,
                BookStoreName = bookStore.Name
            };

            return deleteForm;
        }

        public async Task RemoveBookFromBookStoreConfirmedAsync(int bookId, int bookStoreId)
        {
            var bookInTheCurrentBookStore = await repository.All<BookBookStore>()
                .Where(bbs => bbs.BookId == bookId && bbs.BookStoreId == bookStoreId)
                .FirstOrDefaultAsync();

            await repository.RemoveAsync<BookBookStore>(bookInTheCurrentBookStore);
            await repository.SaveChangesAsync();
        }


        //Article
        public async Task<int> AddArticleAsync(ArticleAddViewModel articleForm)
        {
            Article article = new Article()
            {
                Title = articleForm.Title,
                Content = articleForm.Content,
                ImageUrl = articleForm.ImageUrl,
                DatePublished = DateTime.Now,
                ViewsCount = 0
            };

            await repository.AddAsync(article);
            await repository.SaveChangesAsync();

            return article.Id;
        }

        public async Task<ArticleEditViewModel> EditArticleGetAsync(int articleId)
        {
            var currentArticle = await repository.GetByIdAsync<Article>(articleId);

            var articleForm = new ArticleEditViewModel()
            {
                Id = articleId,
                Title = currentArticle.Title,
                Content = currentArticle.Content,
                ImageUrl = currentArticle.ImageUrl
            };

            return articleForm;
        }

        public async Task<int> EditArticlePostAsync(ArticleEditViewModel articleForm)
        {
            var currentArticle = await repository.GetByIdAsync<Article>(articleForm.Id);

            currentArticle.Title = articleForm.Title;
            currentArticle.Content = articleForm.Content;
            currentArticle.ImageUrl = articleForm.ImageUrl;

            await repository.SaveChangesAsync();

            return currentArticle.Id;
        }

        public async Task<ArticleDeleteViewModel> DeleteArticleAsync(int articleId)
        {
            var currentArticle = await repository.GetByIdAsync<Article>(articleId);

            var deleteForm = new ArticleDeleteViewModel()
            {
                Id = articleId,
                Title = currentArticle.Title,
                ImageUrl = currentArticle.ImageUrl,
                ViewsCount = currentArticle.ViewsCount
            };

            return deleteForm;
        }

        public async Task<int> DeleteArticleConfirmedAsync(int articleId)
        {
            var currentArticle = await repository.GetByIdAsync<Article>(articleId);

            var articleComments = await repository.All<ArticleComment>()
            .Where(ac => ac.ArticleId == articleId)
                .ToListAsync();

            if (articleComments != null && articleComments.Any())
            {
                await repository.RemoveRangeAsync<ArticleComment>(articleComments);
            }

            await repository.RemoveAsync<Article>(currentArticle);
            await repository.SaveChangesAsync();

            return currentArticle.Id;
        }


        //Event
        public async Task<int> AddEventAsync(EventAddViewModel eventForm)
        {
            Event currentEvent = new Event()
            {
                Topic = eventForm.Topic,
                Description = eventForm.Description,
                Location = eventForm.Location,
                StartDate = eventForm.StartDate,
                EndDate = eventForm.EndDate,
                ImageUrl = eventForm.ImageUrl,
                Seats = eventForm.Seats,
                TicketPrice = eventForm.TicketPrice
            };

            await repository.AddAsync(currentEvent);
            await repository.SaveChangesAsync();

            return currentEvent.Id;
        }

        public async Task<EventEditViewModel> EditEventGetAsync(int eventId)
        {
            var currentEvent = await repository.GetByIdAsync<Event>(eventId);

            var eventForm = new EventEditViewModel()
            {
                Id = eventId,
                Topic =  currentEvent.Topic,
                Description= currentEvent.Description,
                Location= currentEvent.Location,
                Seats= currentEvent.Seats,
                TicketPrice = currentEvent.TicketPrice,
                StartDate = currentEvent.StartDate,
                EndDate = currentEvent.EndDate,
                ImageUrl = currentEvent.ImageUrl
            };

            return eventForm;
        }

        public async Task<int> EditEventPostAsync(EventEditViewModel eventForm)
        {
            var currentEvent = await repository.GetByIdAsync<Event>(eventForm.Id);

            currentEvent.Topic = eventForm.Topic;
            currentEvent.Description = eventForm.Description;
            currentEvent.Location = eventForm.Location;
            currentEvent.Seats = eventForm.Seats;
            currentEvent.TicketPrice = eventForm.TicketPrice;
            currentEvent.StartDate = eventForm.StartDate;
            currentEvent.EndDate = eventForm.EndDate;
            currentEvent.ImageUrl = eventForm.ImageUrl;

            await repository.SaveChangesAsync();

            return currentEvent.Id;
        }

        public async Task<EventDeleteViewModel> DeleteEventAsync(int eventId)
        {
            var currentEvent = await repository.GetByIdAsync<Event>(eventId);

            var deleteForm = new EventDeleteViewModel()
            {
                Id = currentEvent.Id,
                Topic = currentEvent.Topic,
                Location = currentEvent.Location,
                ImageUrl = currentEvent.ImageUrl
            };

            return deleteForm;
        }

        public async Task<int> DeleteEventConfirmedAsync(int eventId)
        {
            var currentEvent = await repository.GetByIdAsync<Event>(eventId);

            var eventCarts = await repository.All<EventCart>()
            .Where(ec => ec.EventId == eventId).ToListAsync();

            if (eventCarts != null && eventCarts.Any())
            {
                await repository.RemoveRangeAsync<EventCart>(eventCarts);
            }

            await repository.RemoveAsync<Event>(currentEvent);
            await repository.SaveChangesAsync();

            return currentEvent.Id;
        }
    }
}