namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.ViewModels.Book;
    using NovelNest.Infrastructure.Data;

    [Authorize]
    public class BookController : Controller
    {
        private NovelNestDbContext dbContext;

        public BookController(NovelNestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            //Getting all of the books from the database
            var allBooks = await dbContext.Books
                .AsNoTracking()
                .Select(b => new BookAllViewModel()
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Title = b.Title,
                    Author = b.Author,
                    Price = b.Price,
                })
                .ToListAsync();

            //Returning all of the books to the view
            return View(allBooks);
        }
    }
}