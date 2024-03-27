namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Infrastructure.Data.Models.Articles;

    public interface IArticleService
    {
        Task<bool> ArticleExistsAsync(int articleId);
        Task<Article> FindArticleByIdAsync(int articleId);
        Task<IEnumerable<ArticleAllViewModel>> AllAsync();
        Task<ArticleViewModel> DetailsAsync(int articleId);
        Task<int> AddAsync(ArticleAddViewModel articleForm);
    }
}