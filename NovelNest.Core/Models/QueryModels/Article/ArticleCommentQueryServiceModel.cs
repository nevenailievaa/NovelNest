namespace NovelNest.Core.Models.QueryModels.Article
{
    public class ArticleCommentQueryServiceModel
    {
        public int TotalArticleCommentsCount { get; set; }
        public IEnumerable<ArticleCommentServiceModel> ArticleComments { get; set; } = new HashSet<ArticleCommentServiceModel>();
    }
}
