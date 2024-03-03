namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts;

    public class BookStoreController : BaseController
    {
        private readonly IBookStoreService bookStoreService;

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
