namespace NovelNest.Core.Extensions
{
    using NovelNest.Core.Contracts;

    public static class BookExtensions
    {
        public static string GetInformation(this IBookModel book)
        {
            return book.Title.Replace(" ", "-") + "-" + GetAuthor(book.Author);
        }

        private static string GetAuthor(string author)
        {
            author = string.Join("-", author.Split(" "));
            return author;
        }
    }
}