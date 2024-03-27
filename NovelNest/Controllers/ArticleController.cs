namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Attributes;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.ViewModels.Article;
    using System.Security.Claims;

    public class ArticleController : BaseController
    {
        private readonly IArticleService articleService;
        private readonly IPublisherService publisherService;

        public ArticleController(IArticleService articleService, IPublisherService publisherService)
        {
            this.articleService = articleService;
            this.publisherService = publisherService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allArticles = await articleService.AllAsync();
            return View(allArticles);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            var currentArticle = await articleService.DetailsAsync(id);
            return View(currentArticle);
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Add()
        {
            if (await publisherService.ExistsByIdAsync(User.Id()) == false)
            {
                return Unauthorized();
            }

            var articleForm = new ArticleAddViewModel();

            return View(articleForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> Add(ArticleAddViewModel articleForm)
        {
            if (!ModelState.IsValid)
            {
                return View(articleForm);
            }

            await articleService.AddAsync(articleForm);
            return RedirectToAction(nameof(All));
        }
    }
}