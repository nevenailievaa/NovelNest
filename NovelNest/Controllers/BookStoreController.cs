namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Services;

    public class BookStoreController : BaseController
    {
        private readonly IBookStoreService bookStoreService;

        public BookStoreController(IBookStoreService bookStoreService)
        {
            this.bookStoreService = bookStoreService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allBookStores = await bookStoreService.AllAsync();
            return View(allBookStores);
        }
    }
}
