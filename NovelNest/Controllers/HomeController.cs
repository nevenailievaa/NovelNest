namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts;
    using NovelNest.Models;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IBookStoreService bookStoreService;

        public HomeController(ILogger<HomeController> logger, IBookStoreService bookStoreService)
        {
            this.logger = logger;
            this.bookStoreService = bookStoreService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var bookStoreModel = await bookStoreService.LastTenBookStoresAsync();
            return View(bookStoreModel);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            else if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}