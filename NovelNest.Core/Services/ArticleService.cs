namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Articles;

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
            Article? currentArticle = await repository.All<Article>()
                .FirstOrDefaultAsync(a => a.Id == articleId);

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
            return await repository.AllAsReadOnly<Article>()
                .FirstOrDefaultAsync(a => a.Id == articleId);
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
    }
}
