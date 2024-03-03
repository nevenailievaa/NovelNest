namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.ViewModels.Article;

    public interface IArticleService
    {
        Task<IEnumerable<ArticleAllViewModel>> AllAsync();
    }
}