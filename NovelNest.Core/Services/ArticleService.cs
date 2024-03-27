namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Articles;
    using NovelNest.Infrastructure.Data.Models.Books;
    using NovelNest.Infrastructure.Data.Models.BookUserActions;
    using NovelNest.Infrastructure.Data.Models.Mappings;
    using System.Net;

    public class ArticleService : IArticleService
    {
        private readonly IRepository repository;

        public ArticleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ArticleAllViewModel>> AllAsync()
        {
            return await repository.AllAsReadOnly<Article>()
                .OrderByDescending(a => a.DatePublished)
                .Select(a => new ArticleAllViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    DatePublished = a.DatePublished,
                    ImageUrl = a.ImageUrl,
                    ViewsCount = a.ViewsCount,
                })
                .ToListAsync();
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

            //var articleComments = await repository.All<ArticleComment>()
            //.Where(ac => ac.ArticleId == articleId)
            //    .ToListAsync();


            //if (articleComments != null && articleComments.Any())
            //{
            //    await repository.RemoveRangeAsync(articleComments);
            //}

            await repository.RemoveAsync(currentArticle);
            await repository.SaveChangesAsync();

            return currentArticle.Id;
        }
    }
}
