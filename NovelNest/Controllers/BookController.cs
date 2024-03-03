namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.ViewModels.Book;
    using NovelNest.Infrastructure.Data;

    [Authorize]
    public class BookController : Controller
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            //Getting all of the books from the database
            var allBooks = await bookService.All();

            //Returning all of the books to the view
            return View(allBooks);
        }
    }
}