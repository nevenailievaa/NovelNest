namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Attributes;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Extensions;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.QueryModels.BookStore;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Core.Services;
    using System.Security.Claims;

    public class BookStoreController : BaseController
    {
        private readonly IBookStoreService bookStoreService;
        private readonly IBookService bookService;
        private readonly IPublisherService publisherService;

        public BookStoreController(IBookStoreService bookStoreService, IPublisherService publisherService, IBookService bookService)
        {
            this.bookStoreService = bookStoreService;
            this.publisherService = publisherService;
            this.bookService = bookService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllBookStoresQueryModel model)
        {
            var allEvents = await bookStoreService.AllAsync(
                model.SearchTerm,
                model.Status,
                model.CurrentPage,
                model.BookStoresPerPage);

            model.TotalBookStoresCount = allEvents.TotalBookStoresCount;
            model.BookStores = allEvents.BookStores;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            var currentBookStore = await bookStoreService.DetailsAsync(id);

            if (information != currentBookStore.GetInformation())
            {
                return BadRequest();
            }

            return View(currentBookStore);
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Add()
        {
            if (await publisherService.ExistsByIdAsync(User.Id()) == false)
            {
                return Unauthorized();
            }

            var bookStoreForm = new BookStoreAddViewModel();

            return View(bookStoreForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> Add(BookStoreAddViewModel bookStoreForm)
        {
            if (!ModelState.IsValid)
            {
                return View(bookStoreForm);
            }

            await bookStoreService.AddAsync(bookStoreForm);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            var bookStoreForm = await bookStoreService.EditGetAsync(id);
            return View(bookStoreForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> Edit(BookStoreEditViewModel bookStoreForm)
        {
            if (bookStoreForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(bookStoreForm);
            }

            int id = bookStoreForm.Id;
            await bookStoreService.EditPostAsync(bookStoreForm);
            return RedirectToAction(nameof(Details), new { id, information = bookStoreForm.GetInformation() });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedArticle = await bookStoreService.DeleteAsync(id);

            return View(searchedArticle);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await bookStoreService.BookStoreExistsAsync(id))
            {
                return BadRequest();
            }

            await bookStoreService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllBooks([FromQuery] AllBooksQueryModel model, int id)
        {
            var allBooks = await bookStoreService.AllBooksAsync(
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
        public async Task<IActionResult> SelectBook([FromQuery] AllBooksQueryModel model, int id)
        {
            if (await publisherService.ExistsByIdAsync(User.Id()) == false)
            {
                return Unauthorized();
            }

            var allBooks = await bookStoreService.AllBooksToChooseAsync(
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
        public async Task<IActionResult> AddBook(int id, int secondId)
        {
            if (await publisherService.ExistsByIdAsync(User.Id()) == false)
            {
                return Unauthorized();
            }

            await bookStoreService.AddBookAsync(id, secondId);
            return RedirectToAction(nameof(AllBooks), new { id = secondId });
        }
    }
}