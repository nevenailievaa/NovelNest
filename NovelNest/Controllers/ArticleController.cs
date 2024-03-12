namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Services;

    public class ArticleController : BaseController
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
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
    }
}