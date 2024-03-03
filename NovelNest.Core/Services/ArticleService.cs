namespace NovelNest.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.ViewModels.Article;
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
    }
}
