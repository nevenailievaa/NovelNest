namespace NovelNest.Core.Models.ViewModels.Article
{
    public class ArticleCommentDeleteViewModel
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; } = null!;
        public int CommentId { get; set; }
    }
}