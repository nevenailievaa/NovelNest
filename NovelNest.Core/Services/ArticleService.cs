namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.ViewModels.Article;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Articles;
    using static NovelNest.Infrastructure.Data.Constants.DataConstants.ArticleConstants;

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
    }
}
