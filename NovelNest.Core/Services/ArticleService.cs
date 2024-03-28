namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Article;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Articles;
    using NovelNest.Infrastructure.Data.Models.Books;
    using System.ComponentModel.Design;

    public class ArticleService : IArticleService
    {
        private readonly IRepository repository;

        public ArticleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ArticleQueryServiceModel> AllAsync(
            string? searchTerm = null,
            ArticleSorting sorting = ArticleSorting.Newest,
            int currentPage = 1,
            int articlesPerPage = 8)
        {
            var articlesToShow = repository.AllAsReadOnly<Article>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                articlesToShow = articlesToShow
                .Where(a => normalizedSearchTerm.Contains(a.Title.ToLower())
                || normalizedSearchTerm.Contains(a.Content.ToLower())
                || normalizedSearchTerm.Contains(a.DatePublished.ToString().ToLower())
                || normalizedSearchTerm.Contains(a.ViewsCount.ToString().ToLower())

                || a.Title.ToLower().Contains(normalizedSearchTerm)
                || a.Content.ToLower().Contains(normalizedSearchTerm)
                || a.DatePublished.ToString().ToLower().Contains(normalizedSearchTerm));
            }

            articlesToShow = sorting switch
            {
                ArticleSorting.Oldest => articlesToShow.OrderBy(a => a.Id),
                ArticleSorting.Shortest => articlesToShow.OrderBy(a => a.Content.Length).ThenByDescending(a => a.Id),
                ArticleSorting.Longest => articlesToShow.OrderByDescending(a => a.Content.Length).ThenByDescending(a => a.Id),
                _ => articlesToShow.OrderByDescending(a => a.Id)
            };

            var articles = await articlesToShow
                .Skip((currentPage - 1) * articlesPerPage)
                .Take(articlesPerPage)
                .Select(a => new ArticleServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    ViewsCount = a.ViewsCount,
                    DatePublished = a.DatePublished,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();

            int totalArticles = await articlesToShow.CountAsync();

            return new ArticleQueryServiceModel()
            {
                Articles = articles,
                TotalArticlesCount = totalArticles
            };
        }

        public async Task<bool> ArticleExistsAsync(int articleId)
        {
            return await repository.AllAsReadOnly<Article>()
                .AnyAsync(a => a.Id == articleId);
        }

        public async Task<ArticleViewModel> DetailsAsync(int articleId)
        {
            Article? currentArticle = await repository.GetById<Article>(articleId);

            currentArticle.ViewsCount++;

            await repository.SaveChangesAsync();

            var currentArticleDetails = new ArticleViewModel()
            {
                Id = currentArticle.Id,
                Title= currentArticle.Title,
                DatePublished = currentArticle.DatePublished,
                Content = currentArticle.Content,
                ViewsCount = currentArticle.ViewsCount,
                ImageUrl = currentArticle.ImageUrl
            };

            return currentArticleDetails;
        }

        public async Task<Article> FindArticleByIdAsync(int articleId)
        {
            return await repository.GetById<Article>(articleId);
        }

        public async Task<int> AddAsync(ArticleAddViewModel articleForm)
        {
            Article article = new Article()
            {
                Title = articleForm.Title,
                Content = articleForm.Content,
                ImageUrl = articleForm.ImageUrl,
                DatePublished = DateTime.Now,
                ViewsCount = 0
            };

            await repository.AddAsync(article);
            await repository.SaveChangesAsync();

            return article.Id;
        }

        public async Task<ArticleEditViewModel> EditGetAsync(int articleId)
        {
            var currentArticle = await repository.GetById<Article>(articleId);

            var articleForm = new ArticleEditViewModel()
            {
                Id = articleId,
                Title = currentArticle.Title,
                Content = currentArticle.Content,
                ImageUrl = currentArticle.ImageUrl
            };

            return articleForm;
        }

        public async Task<int> EditPostAsync(ArticleEditViewModel articleForm)
        {
            var currentArticle = await repository.GetById<Article>(articleForm.Id);

            currentArticle.Title = articleForm.Title;
            currentArticle.Content = articleForm.Content;
            currentArticle.ImageUrl = articleForm.ImageUrl;

            await repository.SaveChangesAsync();

            return currentArticle.Id;
        }

        public async Task<ArticleDeleteViewModel> DeleteAsync(int articleId)
        {
            var currentArticle = await repository.GetById<Article>(articleId);

            var deleteForm = new ArticleDeleteViewModel()
            {
                Id = articleId,
                Title = currentArticle.Title,
                ImageUrl = currentArticle.ImageUrl,
                ViewsCount = currentArticle.ViewsCount
            };

            return deleteForm;
        }

        public async Task<int> DeleteConfirmedAsync(int articleId)
        {
            var currentArticle = await repository.GetById<Article>(articleId);

            var articleComments = await repository.All<ArticleComment>()
            .Where(ac => ac.ArticleId == articleId)
                .ToListAsync();

            if (articleComments != null && articleComments.Any())
            {
                await repository.RemoveRangeAsync(articleComments);
            }

            await repository.RemoveAsync(currentArticle);
            await repository.SaveChangesAsync();

            return currentArticle.Id;
        }

        public async Task<ArticleCommentQueryServiceModel> AllArticleCommentsAsync(
            int articleId,
            string articleTitle,
            string? searchTerm = null,
            ArticleCommentSorting sorting = ArticleCommentSorting.Newest,
            int currentPage = 1, int reviewsPerPage = 4)
        {
            var commentsToShow = repository.AllAsReadOnly<ArticleComment>()
                .Where(ac => ac.ArticleId == articleId);

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                commentsToShow = commentsToShow
                .Where(b => normalizedSearchTerm.Contains(b.Title.ToLower()) || b.Title.ToLower().Contains(normalizedSearchTerm)
                || normalizedSearchTerm.Contains(b.Description.ToLower()) || b.Description.ToLower().Contains(normalizedSearchTerm));
            }

            commentsToShow = sorting switch
            {
                ArticleCommentSorting.Oldest => commentsToShow.OrderBy(b => b.Id),
                _ => commentsToShow.OrderByDescending(b => b.Id),
            };

            var comments = await commentsToShow
                .Skip((currentPage - 1) * reviewsPerPage)
                .Take(reviewsPerPage)
                .Select(c => new ArticleCommentServiceModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ArticleId = c.ArticleId,
                    UserId = c.UserId
                })
                .ToListAsync();

            int totalComments = await commentsToShow.CountAsync();

            return new ArticleCommentQueryServiceModel()
            {
                ArticleComments = comments,
                TotalArticleCommentsCount = totalComments
            };
        }

        public async Task<ArticleComment> FindArticleCommentByIdAsync(int id)
        {
            return await repository.All<ArticleComment>()
                .FirstOrDefaultAsync(ac => ac.Id == id);
        }

        public async Task<int> AddArticleCommentAsync(ArticleCommentAddViewModel commentForm, string userId, int articleId)
        {
            var articleComment = new ArticleComment()
            {
                Title = commentForm.Title,
                Description= commentForm.Description,
                UserId = userId,
                ArticleId = articleId
            };

            await repository.AddAsync<ArticleComment>(articleComment);
            await repository.SaveChangesAsync();

            return articleComment.Id;
        }

        public async Task<ArticleCommentEditViewModel> EditArticleCommentGetAsync(int commentId)
        {
            var currentArticleComment = repository.GetById<ArticleComment>(commentId).Result;

            var articleCommentEditForm = new ArticleCommentEditViewModel()
            {
                Id = currentArticleComment.Id,
                Title = currentArticleComment.Title,
                Description = currentArticleComment.Description,
                ArticleId = currentArticleComment.ArticleId,
                UserId = currentArticleComment.UserId
            };

            return articleCommentEditForm;
        }

        public async Task<int> EditArticleCommentPostAsync(ArticleCommentEditViewModel commentForm)
        {
            var currentArticleComment = repository.GetById<ArticleComment>(commentForm.Id).Result;

            currentArticleComment.Title = commentForm.Title;
            currentArticleComment.Description = commentForm.Description;

            await repository.SaveChangesAsync();

            return currentArticleComment.Id;
        }
    }
}
