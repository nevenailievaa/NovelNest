﻿namespace NovelNest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NovelNest.Attributes;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Extensions;
    using NovelNest.Core.Models.QueryModels.Article;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Core.Services;
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
        public async Task<IActionResult> All([FromQuery]AllArticlesQueryModel model)
        {
            var allArticles = await articleService.AllAsync(
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ArticlesPerPage);

            model.TotalArticlesCount = allArticles.TotalArticlesCount;
            model.Articles = allArticles.Articles;

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            var currentArticle = await articleService.DetailsAsync(id);

            if (information != currentArticle.GetArticleInformation())
            {
                return BadRequest();
            }

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

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            var articleForm = await articleService.EditGetAsync(id);
            return View(articleForm);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> Edit(ArticleEditViewModel articleForm)
        {
            if (articleForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(articleForm);
            }

            int id = articleForm.Id;
            await articleService.EditPostAsync(articleForm);
            return RedirectToAction(nameof(Details), new { id, information = articleForm.GetArticleInformation() });
        }

        [HttpGet]
        [MustBePublisher]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBook = await articleService.DeleteAsync(id);

            return View(searchedBook);
        }

        [HttpPost]
        [MustBePublisher]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await articleService.ArticleExistsAsync(id))
            {
                return BadRequest();
            }

            await articleService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllComments(int id, [FromQuery] AllArticleCommentsQueryModel model)
        {
            var article = articleService.FindArticleByIdAsync(id).Result;
            var allArticleComments = await articleService.AllArticleCommentsAsync(
                id,
                article.Title,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.CommentsPerPage);

            model.TotalArticleCommentsCount = allArticleComments.TotalArticleCommentsCount;
            model.ArticleComments = allArticleComments.ArticleComments;
            model.ArticleId = id;
            model.ArticleTitle = article.Title;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddComment(int id)
        {
            string userId = User.Id();

            var articleCommentForm = new ArticleCommentAddViewModel()
            {
                ArticleId = id,
                UserId = userId
            };

            return View(articleCommentForm);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(ArticleCommentAddViewModel articleCommentForm)
        {
            if (!ModelState.IsValid)
            {
                return View(articleCommentForm);
            }

            int newArticleComment = await articleService.AddArticleCommentAsync(articleCommentForm, articleCommentForm.UserId, articleCommentForm.ArticleId);

            return RedirectToAction(nameof(AllComments), new { id = articleCommentForm.ArticleId });
        }
    }
}