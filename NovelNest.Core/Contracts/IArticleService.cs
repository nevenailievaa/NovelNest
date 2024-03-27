namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Infrastructure.Data.Models.Articles;

    public interface IArticleService
    {
        Task<bool> ArticleExistsAsync(int articleId);
        Task<Article> FindArticleByIdAsync(int articleId);
        Task<IEnumerable<ArticleAllViewModel>> AllAsync();
        Task<ArticleViewModel> DetailsAsync(int articleId);
        Task<int> AddAsync(ArticleAddViewModel articleForm);
        Task<ArticleEditViewModel> EditGetAsync(int articleId);
        Task<int> EditPostAsync(ArticleEditViewModel articleForm);
    }
}