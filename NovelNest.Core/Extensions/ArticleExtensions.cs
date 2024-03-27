using NovelNest.Core.Contracts;

namespace NovelNest.Core.Extensions
{
    public static class ArticleExtensions
    {
        public static string GetArticleInformation(this IArticleModel book)
        {
            return book.Title.Replace(" ", "-");
        }
    }
}
