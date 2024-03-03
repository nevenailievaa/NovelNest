using Microsoft.AspNetCore.Mvc;
using NovelNest.Core.Contracts.BookStore;

namespace NovelNest.Controllers
{
    public class BookStoreController : Controller
    {
        private IBookStoreService bookStoreService;

        public BookStoreController(IBookStoreService bookStoreService)
        {
            this.bookStoreService = bookStoreService;
        }

        //public async Task<IActionResult> All()
        //{
        //    return View();
        //}
    }
}
