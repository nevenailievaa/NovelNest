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
        public async Task<IActionResult> Mine(string id, [FromQuery] AllBooksQueryModel model)
        {
            var userId = User.Id();

            if (userId != id)
            {
                return Unauthorized();
            }

            var bookCollections = new AllBookCollectionsModel()
            {
                booksUserWantsToRead = await bookService.AllWantToReadBooksIdsByUserIdAsync(
                userId,
                model.Genre,
                model.CoverType,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.BooksPerPage),
                booksUserCurrentlyReading = await bookService.AllCurrentlyReadingBooksIdsByUserIdAsync(userId),
                booksUserRead = await bookService.AllReadBooksIdsByUserIdAsync(userId)
            };

            return View(bookCollections);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsWantToRead(int id)
        {
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBook = await bookService.DetailsAsync(id);
            return View(currentBook);
        }

        [HttpGet]
        public async Task<IActionResult> WantToRead([FromQuery] AllBooksQueryModel model)
        {
            var userId = User.Id();

            var allBooks = await bookService.AllWantToReadBooksIdsByUserIdAsync(
                userId,
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

        [HttpGet]
        public async Task<IActionResult> AddWantToRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }
            if (await bookService.BookIsInAnotherCollectionAsync(id, userId))
            {
                await bookService.RemoveBookFromAllCollectionsAsync(id, userId);
            }

            await bookService.AddWantToReadBookAsync(id, userId);
            return RedirectToAction(nameof(WantToRead));
        }

        [HttpGet]
        public async Task<IActionResult> AddCurrentlyReading(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }
            if (await bookService.BookIsInAnotherCollectionAsync(id, userId))
            {
                await bookService.RemoveBookFromAllCollectionsAsync(id, userId);
            }

            await bookService.AddCurrentlyReadingBookAsync(id, userId);
            return RedirectToAction(nameof(CurrentlyReading));
        }

        [HttpGet]
        public async Task<IActionResult> AddRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }
            if (await bookService.BookIsInAnotherCollectionAsync(id, userId))
            {
                await bookService.RemoveBookFromAllCollectionsAsync(id, userId);
            }

            await bookService.AddReadBookAsync(id, userId);
            return RedirectToAction(nameof(Read));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveWantToRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id) || await bookService.BookIsNotWantToReadAsync(id, userId))
            {
                return BadRequest();
            }

            await bookService.RemoveWantToReadBookAsync(id, userId);
            return RedirectToAction(nameof(WantToRead));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCurrentlyReading(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id) || await bookService.BookIsNotCurrentlyReadingAsync(id, userId))
            {
                return BadRequest();
            }

            await bookService.RemoveCurrentlyReadingBookAsync(id, userId);
            return RedirectToAction(nameof(CurrentlyReading));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRead(int id)
        {
            string userId = User.Id();

            if (!await bookService.BookExistsAsync(id) || await bookService.BookIsNotReadAsync(id, userId))
            {
                return BadRequest();
            }

            await bookService.RemoveReadBookAsync(id, userId);
            return RedirectToAction(nameof(Read));
        }
    }
}