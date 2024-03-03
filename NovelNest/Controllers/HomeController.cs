namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts.BookStore;
    using NovelNest.Core.Services.BookStore;
    using NovelNest.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private IBookStoreService bookStoreService;

        public HomeController(ILogger<HomeController> logger, IBookStoreService bookStoreService)
        {
            this.logger = logger;
            this.bookStoreService = bookStoreService;
        }

        public async Task<IActionResult> Index()
        {
            var bookStoreModel = await bookStoreService.LastTenBookStores();
            return View(bookStoreModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}