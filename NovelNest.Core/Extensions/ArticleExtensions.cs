namespace NovelNest.Core.Extensions
{
    using NovelNest.Core.Contracts;

    public static class ArticleExtensions
    {
        public static string GetArticleInformation(this IArticleModel book)
        {
            return book.Title.Replace(" ", "-");
        }
    }
}
