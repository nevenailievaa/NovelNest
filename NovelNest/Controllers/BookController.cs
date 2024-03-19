namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Attributes;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Book;
    using System.Security.Claims;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IPublisherService publisherService;

        public BookController(IBookService bookService, IPublisherService publisherService)
        {
            this.bookService = bookService;
            this.publisherService = publisherService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllBooksQueryModel model)
        {
            var allBooks = await bookService.AllAsync(
                model.Genre,
                model.CoverType,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage);

            model.TotalBooksCount = allBooks.TotalBooksCount;
            model.Books = allBooks.Books;
            model.Genres = await bookService.AllGenresNamesAsync();
            model.CoverTypes = await bookService.AllCoverTypesNamesAsync();

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await bookService.DetailsAsync(id);
            return View(currentBook);
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Add()
        {
            if (await publisherService.ExistsByIdAsync(User.Id()) == false)
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
        public async Task<IActionResult> Add(BookAddViewModel bookForm)
        {
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

            int newBookId = await bookService.AddAsync(bookForm);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var bookForm = await bookService.EditGetAsync(id);
            return View(bookForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> Edit(BookEditViewModel bookForm)
        {
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

            await bookService.EditPostAsync(bookForm);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBook = await bookService.DeleteAsync(id);

            return View(searchedBook);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            await bookService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine(string id)
        {
            var userId = User.Id();

            if (userId != id)
            {
                return Unauthorized();
            }

            var bookCollections = new AllBookCollectionsModel()
            {
                booksUserWantsToRead = await bookService.AllWantToReadBooksIdsByUserIdAsync(userId),
                booksUserCurrentlyReading = await bookService.AllCurrentlyReadingBooksIdsByUserIdAsync(userId),
                booksUserRead = await bookService.AllReadBooksIdsByUserIdAsync(userId)
            };

            return View(bookCollections);
        }

        [HttpGet]
        public async Task<IActionResult> WantToRead(string id)
        {
            var userId = User.Id();

            if (userId != id)
            {
                return Unauthorized();
            }

            var wantToReadBooks = await bookService.AllWantToReadBooksIdsByUserIdAsync(userId);
            return View(wantToReadBooks);
        }

        [HttpGet]
        public async Task<IActionResult> CurrentlyReading(string id)
        {
            var userId = User.Id();

            if (userId != id)
            {
                return Unauthorized();
            }

            var wantCurrentlyReadingBooks = await bookService.AllCurrentlyReadingBooksIdsByUserIdAsync(userId);
            return View(wantCurrentlyReadingBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Read(string id)
        {
            var userId = User.Id();

            if (userId != id)
            {
                return Unauthorized();
            }

            var readBooks = await bookService.AllReadBooksIdsByUserIdAsync(userId);
            return View(readBooks);
        }
    }
}