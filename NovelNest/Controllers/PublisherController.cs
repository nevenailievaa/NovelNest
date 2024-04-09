namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Attributes;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Extensions;
    using NovelNest.Core.Models.ViewModels.Book;
    using System.Security.Claims;

    public class PublisherController : BaseController
    {
        private readonly IPublisherService publisherService;
        private readonly IBookService bookService;

        public PublisherController(IPublisherService publisherService, IBookService bookService)
        {
            this.publisherService = publisherService;
            this.bookService = bookService;
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> AddBook()
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
        public async Task<IActionResult> AddBook(BookAddViewModel bookForm)
        {
            if (await publisherService.ExistsByIdAsync(User.Id()) == false)
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
            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            await publisherService.DeleteBookConfirmedAsync(id);

            return RedirectToAction("All", "Book");
        }
    }
}