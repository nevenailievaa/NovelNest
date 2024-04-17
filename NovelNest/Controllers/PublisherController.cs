namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Attributes;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Extensions;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Core.Models.ViewModels.Event;
    using System.Security.Claims;

    public class PublisherController : BaseController
    {
        private readonly IPublisherService publisherService;
        private readonly IBookService bookService;
        private readonly IBookStoreService bookStoreService;
        private readonly IArticleService articleService;
        private readonly IEventService eventService;

        public PublisherController(IPublisherService publisherService, IBookService bookService,
            IBookStoreService bookStoreService, IArticleService articleService, IEventService eventService)
        {
            this.publisherService = publisherService;
            this.bookService = bookService;
            this.bookStoreService = bookStoreService;
            this.articleService = articleService;
            this.eventService=eventService;
        }

        //Books
        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> AddBook()
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var bookForm = new BookAddViewModel()
            {
                Genres = await bookService.AllGenresAsync(),
                CoverTypes = await bookService.AllCoverTypesAsync(),
            };

            return View(bookForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> AddBook(BookAddViewModel bookForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (await bookService.GenreExistsAsync(bookForm.GenreId) == false)
            {
                ModelState.AddModelError(nameof(bookForm.GenreId), "Genre does not exist!");
            }
            else if (await bookService.CoverTypeExistsAsync(bookForm.CoverTypeId) == false)
            {
                ModelState.AddModelError(nameof(bookForm.CoverTypeId), "Cover Type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                bookForm.Genres = await bookService.AllGenresAsync();
                bookForm.CoverTypes = await bookService.AllCoverTypesAsync();
                return View(bookForm);
            }

            int newBookId = await publisherService.AddBookAsync(bookForm);
            return RedirectToAction("All", "Book");
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> EditBook(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var bookForm = await publisherService.EditBookGetAsync(id);
            return View(bookForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> EditBook(BookEditViewModel bookForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (bookForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                bookForm.Genres = await bookService.AllGenresAsync();
                bookForm.CoverTypes = await bookService.AllCoverTypesAsync();

                return View(bookForm);
            }

            int id = bookForm.Id;
            await publisherService.EditBookPostAsync(bookForm);
            return RedirectToAction("Details", "Book", new { id, information = bookForm.GetInformation() });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBook = await publisherService.DeleteBookAsync(id);

            return View(searchedBook);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteBookConfirmed(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            await publisherService.DeleteBookConfirmedAsync(id);

            return RedirectToAction("All", "Book");
        }

        //BookStores
        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> AddBookStore()
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var bookStoreForm = new BookStoreAddViewModel();

            return View(bookStoreForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> AddBookStore(BookStoreAddViewModel bookStoreForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(bookStoreForm);
            }

            await publisherService.AddBookStoreAsync(bookStoreForm);
            return RedirectToAction("All", "BookStore");
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> EditBookStore(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            var bookStoreForm = await publisherService.EditBookStoreGetAsync(id);
            return View(bookStoreForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> EditBookStore(BookStoreEditViewModel bookStoreForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (bookStoreForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(bookStoreForm);
            }

            int id = bookStoreForm.Id;
            await publisherService.EditBookStorePostAsync(bookStoreForm);
            return RedirectToAction("Details", "BookStore", new { id, information = bookStoreForm.GetInformation() });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> DeleteBookStore(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBookStore = await publisherService.DeleteBookStoreAsync(id);

            return View(searchedBookStore);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteBookStoreConfirmed(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            await publisherService.DeleteBookStoreConfirmedAsync(id);

            return RedirectToAction("All", "BookStore");
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> SelectBookFromBookStore([FromQuery] AllBooksQueryModel model, int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var allBooks = await publisherService.AllBooksToChooseAsync(
                id,
                model.Genre,
                model.CoverType,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage);

            model.TotalBooksCount = allBooks.TotalBooksCount;
            model.Books = allBooks.Books;
            model.BookStoreId = id;
            model.Genres = await bookService.AllGenresNamesAsync();
            model.CoverTypes = await bookService.AllCoverTypesNamesAsync();

            return View(model);
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> AddBookToBookStore(int id, int secondId)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookStoreService.BookStoreExistsAsync(secondId) || !await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            await publisherService.AddBookToBookStoreAsync(id, secondId);
            return RedirectToAction("AllBooks", "BookStore", new { id = secondId });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> RemoveBookFromBookStore(int id, int secondId)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookStoreService.BookStoreExistsAsync(secondId) || !await bookService.BookExistsAsync(id) || !await publisherService.BookExistsInBookStoreAsync(id, secondId))
            {
                return BadRequest();
            }

            var searchedBookBookStore = await publisherService.RemoveBookFromBookStoreAsync(id, secondId);

            return View(searchedBookBookStore);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> RemoveBookFromBookStoreConfirmed(int bookId, int bookStoreId)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await bookStoreService.BookStoreExistsAsync(bookStoreId) || !await bookService.BookExistsAsync(bookId) || !await publisherService.BookExistsInBookStoreAsync(bookId, bookStoreId))
            {
                return BadRequest();
            }

            await publisherService.RemoveBookFromBookStoreConfirmedAsync(bookId, bookStoreId);

            return RedirectToAction("AllBooks", "BookStore", new { id = bookStoreId });
        }

        //Articles
        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> AddArticle()
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var articleForm = new ArticleAddViewModel();

            return View(articleForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> AddArticle(ArticleAddViewModel articleForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(articleForm);
            }

            await publisherService.AddArticleAsync(articleForm);
            return RedirectToAction("All", "Article");
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> EditArticle(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            var articleForm = await publisherService.EditArticleGetAsync(id);
            return View(articleForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> EditArticle(ArticleEditViewModel articleForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (articleForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(articleForm);
            }

            int id = articleForm.Id;
            await publisherService.EditArticlePostAsync(articleForm);
            return RedirectToAction("Details", "Article", new { id, information = articleForm.GetArticleInformation() });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedArticle = await publisherService.DeleteArticleAsync(id);

            return View(searchedArticle);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteArticleConfirmed(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            await publisherService.DeleteArticleConfirmedAsync(id);

            return RedirectToAction("All", "Article");
        }

        //Events
        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> AddEvent()
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var eventForm = new EventAddViewModel();

            return View(eventForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> AddEvent(EventAddViewModel eventForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (eventForm.StartDate >= eventForm.EndDate)
            {
                ModelState.AddModelError("StartDate", "Invalid timespan!");
                ModelState.AddModelError("EndDate", "Invalid timespan!");
            }

            if (!ModelState.IsValid)
            {
                return View(eventForm);
            }

            await publisherService.AddEventAsync(eventForm);
            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> EditEvent(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            var eventForm = await publisherService.EditEventGetAsync(id);
            return View(eventForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> EditEvent(EventEditViewModel eventForm)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (eventForm == null)
            {
                return BadRequest();
            }
            if (eventForm.StartDate >= eventForm.EndDate)
            {
                ModelState.AddModelError("StartDate", "Invalid timespan!");
                ModelState.AddModelError("EndDate", "Invalid timespan!");
            }
            if (!ModelState.IsValid)
            {
                return View(eventForm);
            }

            int id = eventForm.Id;
            await publisherService.EditEventPostAsync(eventForm);
            return RedirectToAction("Details", "Event", new { id, information = eventForm.GetInformation() });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedEvent = await publisherService.DeleteEventAsync(id);

            return View(searchedEvent);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteEventConfirmed(int id)
        {
            if (await publisherService.ExistsByUserIdAsync(User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            await publisherService.DeleteEventConfirmedAsync(id);

            return RedirectToAction("All", "Event");
        }
    }
}