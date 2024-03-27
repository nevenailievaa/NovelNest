namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Article;
    using NovelNest.Core.Models.QueryModels.Book;
    using NovelNest.Core.Models.ViewModels.Article;
    using NovelNest.Core.Models.ViewModels.Book;
    using NovelNest.Infrastructure.Data.Models.Articles;

    public interface IArticleService
    {
        Task<bool> ArticleExistsAsync(int articleId);
        Task<Article> FindArticleByIdAsync(int articleId);
        Task<ArticleQueryServiceModel> AllAsync(
            string? searchTerm = null,
            ArticleSorting sorting = ArticleSorting.Newest,
            int currentPage = 1,
            int articlesPerPage = 4);
        Task<ArticleViewModel> DetailsAsync(int articleId);
        Task<int> AddAsync(ArticleAddViewModel articleForm);
        Task<ArticleEditViewModel> EditGetAsync(int articleId);
        Task<int> EditPostAsync(ArticleEditViewModel articleForm);
        Task<ArticleDeleteViewModel> DeleteAsync(int articleId);
        Task<int> DeleteConfirmedAsync(int articleId);
    }
}