namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.QueryModels.BookStore;

    public class BookStoreController : BaseController
    {
        private readonly IBookStoreService bookStoreService;
        private readonly IPublisherService publisherService;

        public BookStoreController(IBookStoreService bookStoreService, IPublisherService publisherService)
        {
            this.bookStoreService = bookStoreService;
            this.publisherService = publisherService;
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
    }
}